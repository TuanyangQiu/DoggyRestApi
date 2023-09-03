using AutoMapper;
using DoggyRestApi.DTOs;
using DoggyRestApi.Models;
using DoggyRestApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace DoggyRestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITouristRouteRepository _touristRouteRepository;
        private readonly IMapper _mapper;

        public ShoppingCartController(IHttpContextAccessor httpContextAccessor,
                                      ITouristRouteRepository touristRouteRepository,
                                      IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _touristRouteRepository = touristRouteRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetShoppingCart")]
        public async Task<IActionResult> GetShoppingCart()
        {
            var userId = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrWhiteSpace(userId))
                return NotFound(new { err = "The user does not exist" });


            ShoppingCart? shoppingCart = await _touristRouteRepository.GetShoppingCartByIdAsync(userId);
            if (shoppingCart == null)
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  new { err = "The shopping cart information for the user cannot be retrived" });

            return Ok(_mapper.Map<ShoppingCartDTO>(shoppingCart));
        }

        [HttpPost("item")]
        public async Task<IActionResult> AddItem2ShoppingCart([FromBody] AddItem2ShoppingCartDTO addItem2ShoppingCartDTO)
        {
            if (addItem2ShoppingCartDTO == null)
                return BadRequest(new { err = "request body cannot be empty" });

            if (addItem2ShoppingCartDTO.TouristRouteId == Guid.Empty)
                return BadRequest(new { err = "Tourist route id cannot be empty" });

            var userId = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrWhiteSpace(userId))
                return NotFound(new { err = "The user does not exist" });

            ShoppingCart? shoppingCart = await _touristRouteRepository.GetShoppingCartByIdAsync(userId);
            if (shoppingCart == null)
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  new { err = "The shopping cart information for the user cannot be retrived" });

            TouristRoute? touristRoute = await _touristRouteRepository.GetTouristRouteByIdAsync(addItem2ShoppingCartDTO.TouristRouteId);
            if (touristRoute == null)
                return NotFound(new { err = $"The tourist route with id {addItem2ShoppingCartDTO.TouristRouteId} does not exist" });


            LineItem item = new LineItem()
            {
                TouristRouteId = addItem2ShoppingCartDTO.TouristRouteId,
                OriginalPrice = touristRoute.OriginalPrice,
                DiscountPercent = touristRoute.DiscountPercent,
                Title = touristRoute.Title,
                Description = touristRoute.Description,
                DepartureTime = touristRoute.DepartureTime,
                DepartureCity = touristRoute?.DepartureCity,
                Rating = touristRoute?.Rating,
                TravelDays = touristRoute?.TravelDays,
                TripType = touristRoute.TripType
            };

            shoppingCart.LineItems.Add(item);

            if (!await _touristRouteRepository.SaveAsync())
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  new { err = "error occurred while adding item to the shopping cart" });



            return Ok(_mapper.Map<ShoppingCartDTO>(shoppingCart));
        }



        [HttpDelete("item")]
        public async Task<IActionResult> DeleteMultipleShoppingCartItems([FromQuery] List<long> deleteItem)
        {
            if (deleteItem == null || deleteItem.Count == 0)
                return BadRequest(new { err = "item id being deleted cannot be empty" });

            var userId = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrWhiteSpace(userId))
                return NotFound(new { err = "The user does not exist" });

            ShoppingCart? shoppingCart = await _touristRouteRepository.GetShoppingCartByIdAsync(userId);
            if (shoppingCart == null)
                return StatusCode(StatusCodes.Status500InternalServerError,
                   new { err = "error occurred while querying shopping cart" });

            //Prevent deleting items that DO NOT belong to this user
            var itemsBeingDeleted = shoppingCart.LineItems.Where(i => deleteItem.Contains(i.Id)).ToList();
            foreach (var item in itemsBeingDeleted)
                shoppingCart.LineItems.Remove(item);

            if (!await _touristRouteRepository.SaveAsync())
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  new { err = "error occurred while deleting items from shopping cart" });


            return Ok();
        }



        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout()
        {
            var userId = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrWhiteSpace(userId))
                return NotFound(new { err = "The user does not exist" });

            ShoppingCart? shoppingCart = await _touristRouteRepository.GetShoppingCartByIdAsync(userId);
            if (shoppingCart == null)
                return StatusCode(StatusCodes.Status500InternalServerError,
                   new { err = "error occurred while querying shopping cart" });

            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                OwnerId = userId,
                OrderItems = _mapper.Map<List<OrderedItem>>(shoppingCart.LineItems),
                OrderStatus = OrderStatusEnum.Pending,
                OrderCreationDateTime = DateTime.UtcNow
            };

            //clear shopping items in shopping cart before creating order
            shoppingCart.LineItems.Clear();

            await _touristRouteRepository.AddOrderAsync(order);
            if (!await _touristRouteRepository.SaveAsync())
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  new { err = "error occurred while deleting items from shopping cart" });


            return Ok(_mapper.Map<OrderDTO>(order));
        }
    }
}
