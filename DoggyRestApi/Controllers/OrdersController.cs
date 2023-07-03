using AutoMapper;
using DoggyRestApi.DTOs;
using DoggyRestApi.Models;
using DoggyRestApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DoggyRestApi.ResourceParameter;
using DoggyRestApi.Helper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace DoggyRestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrdersController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITouristRouteRepository _touristRouteRepository;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUrlHelper _urlHelper;

        public OrdersController(IHttpContextAccessor httpContextAccessor,
                                ITouristRouteRepository touristRouteRepository,
                                IMapper mapper,
                                IHttpClientFactory httpClientFactory,
                                IUrlHelperFactory urlHelperFactory,
                                IActionContextAccessor actionContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _touristRouteRepository = touristRouteRepository;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext!);

        }


        [HttpGet(Name = "GetOrders")]
        public async Task<IActionResult> GetOrders([FromQuery] PaginationParam paginationParam)
        {
            var userId = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrWhiteSpace(userId))
                return NotFound(new { err = "The user does not exist" });


            PagingQuery<Order> orders = await _touristRouteRepository.GetOrdersByUserIdAsync(userId, paginationParam);
            if (orders.DataList.Count == 0)
                return NotFound(new { err = "no order can be found!" });

            //related page link and pagination info will be responsed in the header to make APIs discoverable
            PaginationUrlHelper pageUrlHelper = new PaginationUrlHelper(_urlHelper, "GetOrders", orders.PaginationInfo, null);
            Response.Headers.Add("x-pagination", pageUrlHelper.GetPaginationResponseHeader());


            return Ok(_mapper.Map<List<OrderDTO>>(orders.DataList));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByOrderId([FromRoute] Guid id, PaginationParam paginationParam)
        {
            if (id == Guid.Empty)
                return BadRequest(new { err = "order id cannot be empty!" });

            var userId = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrWhiteSpace(userId))
                return NotFound(new { err = "The user does not exist" });

            PagingQuery<Order> orders = await _touristRouteRepository.GetOrdersByUserIdAsync(userId, paginationParam);
            if (orders.DataList.Count == 0)
                return NoContent();

            if (!orders.DataList.Any(o => o.Id == id))
                return NotFound(new { err = $"current use does not have order with id {id}" });

            Order? order = await _touristRouteRepository.GetOrderByOrderId(id);

            return Ok(_mapper.Map<OrderDTO>(order));
        }

        [HttpPost("placeOrder/{orderId}")]
        public async Task<IActionResult> PlaceOrder([FromRoute] Guid orderId)
        {
            //此处需要先判断orderid是否属于该用户！！！
            //防止支付请求被重复发送和处理！！！
            Order? order = await _touristRouteRepository.GetOrderByOrderId(orderId);
            if (order == null)
                return NotFound(new { err = $"cannot find order with id {orderId}" });

            //set the trigger of the state machine to 'processing'
            order.StartProcessPayment();

            //This is a settlement center simulator for processing payment
            HttpClient httpClient = _httpClientFactory.CreateClient();
            bool returnOk = true;
            string paymentSimulatorUrl = $"http://localhost:5022/PaymentSimulator/?orderId={orderId}&returnOK={returnOk}";

            //process the result returned by the settlement center simulator
            bool? isApproved = false;
            HttpResponseMessage response = await httpClient.PostAsync(paymentSimulatorUrl, null);
            if (response.IsSuccessStatusCode)
            {
                order.TransactionMetaData = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(order.TransactionMetaData))
                    return StatusCode(StatusCodes.Status500InternalServerError, new { err = "Metadata is null, payment cannot be processed" });

                var jo = JsonConvert.DeserializeObject(order.TransactionMetaData) as JObject;
                if (jo == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new { err = "jo is null, payment cannot be processed" });

                isApproved = jo["approved"]?.Value<bool>();
            }

            //trigger state machine 
            if (isApproved == true)
                order.ProcessApprovedPayment();
            else
                order.ProcessRejectedPayment();

            if (!await _touristRouteRepository.SaveAsync())
                return StatusCode(StatusCodes.Status500InternalServerError, new { err = "error occurred while saving order data" });


            if (isApproved == true)
                return Ok(new { message = "payment has been approved" });
            else
                return Ok(new { message = "payment has been rejected" });

        }


        //其他方法：客户取消订单，客户取消支付要求退款。。。
    }

}
