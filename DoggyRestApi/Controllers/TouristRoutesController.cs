using AutoMapper;
using DoggyRestApi.DTOs;
using DoggyRestApi.Helper;
using DoggyRestApi.Models;
using DoggyRestApi.ResourceParameter;
using DoggyRestApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Net.Http.Headers;
using System.Dynamic;

namespace DoggyRestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private readonly ITouristRouteRepository _touristRouteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IUrlHelper _urlHelper;

        public TouristRoutesController(ITouristRouteRepository touristRouteRepository,
                                       IMapper mapper,
                                       ILogger<TouristRoutesController> logger,
                                       IUrlHelperFactory urlHelperFactory,
                                       IActionContextAccessor actionContextAccessor)
        {
            _touristRouteRepository = touristRouteRepository;
            _mapper = mapper;
            _logger = logger;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext!);

            _logger.LogInformation("Enter TouristRoutesController constructor");
        }



        [HttpGet(Name = "GetAllTouristRoutes")]
        public async Task<IActionResult> GetAllTouristRoutes([FromQuery] QueryTouristRoutesParam parameters, [FromQuery] PaginationParam paginationParam)
        {

            PagingQuery<TouristRoute> touristRoutesFromRepo = await _touristRouteRepository.GetTouristRoutesAsync(parameters, paginationParam);
            if (touristRoutesFromRepo.DataList.Count == 0)
                return NotFound(new { err = "No data can be queried out from repository!" });

            //related page link and pagination info will be responsed in the header to make APIs discoverable
            PaginationUrlHelper pageUrlHelper = new PaginationUrlHelper(_urlHelper, "GetAllTouristRoutes", touristRoutesFromRepo.PaginationInfo, parameters);
            Response.Headers.Add("x-pagination", pageUrlHelper.GetPaginationResponseHeader());

            List<TouristRouteDTO> touristRouteDto = _mapper.Map<List<TouristRouteDTO>>(touristRoutesFromRepo.DataList);
            return Ok(touristRouteDto.ShapeDataForIEnumerable(parameters.Fields));
        }

        [HttpGet("{id}", Name = "GetTouristRouteById")]
        public async Task<IActionResult> GetTouristRouteById([FromHeader(Name = "Accept")] string mediaType,
                                                             [FromRoute] Guid id,
                                                             [FromQuery] string? fields)
        {
            if (id == Guid.Empty)
                return BadRequest("tourist id cannot be empty!");

            TouristRoute? touristRoute = await _touristRouteRepository.GetTouristRouteByIdAsync(id);
            if (touristRoute == null)
                return NotFound($"the tourist route with {id} cannot be found");

            ExpandoObject expObject = _mapper.Map<TouristRouteDTO>(touristRoute).ShapeData4SingleObject(fields);

            //response with related apis links to achieve api self-discovoery and HATEOAS
            if (MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue? parsedMediatype) &&
                parsedMediatype.MediaType.StartsWith("application/vnd.Tuanyang.hateoas+", StringComparison.OrdinalIgnoreCase))
            {
                List<LinkDTO> linkDTOs = new List<LinkDTO>();
                linkDTOs.GetRelatedLink(Url, routeName: "GetTouristRouteById", obj: new { id, fields }, rel: "self", method: "GET").
                         GetRelatedLink(Url, routeName: "CreateTouristRoute", obj: null, rel: "Create_Tourist_Route", method: "POST").
                         GetRelatedLink(Url, routeName: "PartiallyUpdateTouristRoute", obj: new { touristRouteId = touristRoute.Id }, rel: "Partial_Update_Tourist_Route", method: "PATCH").
                         GetRelatedLink(Url, routeName: "DeleteTouristRoute", obj: new { touristRouteId = touristRoute.Id }, rel: "Delete_Tourist_Route", method: "DELETE");
                expObject.TryAdd("links", linkDTOs);
            }
            return Ok(expObject);
        }

        [HttpPost(Name = "CreateTouristRoute")]
        [Authorize(AuthenticationSchemes = "Bearer")]//jwt token
        [Authorize(Roles = JwtClaimRoles.AdminRole)]//only Admin has permission to create a tourist route
        public async Task<IActionResult> CreateTouristRoute([FromBody] NewTouristRouteDTO newTouristRouteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TouristRoute newTouristRoute = _mapper.Map<TouristRoute>(newTouristRouteDto);
            _touristRouteRepository.AddTouristRoute(newTouristRoute);
            if (await _touristRouteRepository.SaveAsync())
            {
                TouristRouteDTO touristRouteDtoToReturn = _mapper.Map<TouristRouteDTO>(newTouristRoute);
                return CreatedAtAction("GetTouristRouteById", new { id = touristRouteDtoToReturn.Id }, touristRouteDtoToReturn);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);

        }


        [HttpPatch("{touristRouteId}", Name = "PartiallyUpdateTouristRoute")]
        [Authorize(AuthenticationSchemes = "Bearer")]//jwt token
        [Authorize(Roles = JwtClaimRoles.AdminRole)]//only Admin has permission to update a tourist route
        public async Task<IActionResult> PartiallyUpdateTouristRoute([FromRoute] Guid touristRouteId, [FromBody] JsonPatchDocument<UpdateTouristRouteDTO> patchDoc)
        {
            TouristRoute? touristRouteFromRepo = await _touristRouteRepository.GetTouristRouteByIdAsync(touristRouteId);
            if (touristRouteFromRepo == null)
                return NotFound(new { err = $"Tourist Route ID {touristRouteId} not found!" });

            UpdateTouristRouteDTO updateTouristRouteDto = _mapper.Map<UpdateTouristRouteDTO>(touristRouteFromRepo);

            patchDoc.ApplyTo(updateTouristRouteDto, ModelState);

            if (!TryValidateModel(updateTouristRouteDto))
                return BadRequest(ModelState);


            _mapper.Map(updateTouristRouteDto, touristRouteFromRepo);
            touristRouteFromRepo.Id = touristRouteId;

            if (await _touristRouteRepository.SaveAsync())
                return CreatedAtAction("GetTouristRouteById", new { touristRouteId }, updateTouristRouteDto);


            return BadRequest(new { err = "internal error " });
        }

        [HttpDelete("{touristRouteId}", Name = "DeleteTouristRoute")]
        [Authorize(AuthenticationSchemes = "Bearer")]//jwt token
        [Authorize(Roles = JwtClaimRoles.AdminRole)]//only Admin has permission to delete a tourist route
        public async Task<IActionResult> DeleteTouristRoute([FromRoute] Guid touristRouteId)
        {
            TouristRoute? touristRouteFromRepo = await _touristRouteRepository.GetTouristRouteByIdAsync(touristRouteId);
            if (touristRouteFromRepo == null)
                return NotFound(new { err = $"Tourist Route ID {touristRouteId} not found!" });


            _touristRouteRepository.DeleteTouristRoute(touristRouteFromRepo);
            if (await _touristRouteRepository.SaveAsync())
                return Ok(new { message = "successfully deleted" });

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
