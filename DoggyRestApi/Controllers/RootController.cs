using DoggyRestApi.DTOs;
using DoggyRestApi.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace DoggyRestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RootController : ControllerBase
    {
        private readonly IUrlHelper _urlHelper;
        public RootController(IUrlHelperFactory urlHelperFactory,
                                       IActionContextAccessor actionContextAccessor)
        {
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext!);
        }


        [HttpGet(Name = "GetRootLink")]
        public IActionResult GetRootLink()
        {
            List<LinkDTO> links = new List<LinkDTO>();

            links.GetRelatedLink(Url.Link("GetRootLink", null), rel: "self", httpMethod: "GET").
                  GetRelatedLink(Url.Link("GetAllTouristRoutes", null), rel: "Get_All_TouristRoutes", httpMethod: "GET").
                  GetRelatedLink(Url.Link("CreateTouristRoute", null), rel: "Create_TouristRoute", httpMethod: "POST").
                  GetRelatedLink(Url.Link("Login", null), rel: "User_Login", httpMethod: "POST").
                  GetRelatedLink(Url.Link("RegisterNewUser", null), rel: "Register_New_User", httpMethod: "POST").
                  GetRelatedLink(Url.Link("GetShoppingCart", null), rel: "Get_ShoppingCart", httpMethod: "GET").
                  GetRelatedLink(Url.Link("GetOrders", null), rel: "Get_Orders", httpMethod: "GET");



            return Ok(links);
        }



    }
}
