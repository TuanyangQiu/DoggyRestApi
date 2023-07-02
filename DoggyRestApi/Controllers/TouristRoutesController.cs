using AutoMapper;
using DoggyRestApi.DTOs;
using DoggyRestApi.Models;
using DoggyRestApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DoggyRestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private readonly ITouristRouteRepository touristRouteRepository;
        private readonly IMapper mapper;
        private readonly ILogger logger;
        public TouristRoutesController(ITouristRouteRepository touristRouteRepository, IMapper mapper, ILogger<TouristRoutesController> logger)
        {
            this.touristRouteRepository = touristRouteRepository;
            this.mapper = mapper;
            this.logger = logger;

            this.logger.LogInformation("Enter TouristRoutesController constructor");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTouristRoutes([FromQuery] QueryTouristRoutesParam parameters)
        {
            var touristRoutesFromRepo = await touristRouteRepository.GetTouristRoutesAsync(parameters);
            if (touristRoutesFromRepo?.Count() <= 0)
                return NotFound(new { err = "No data can be queried out from repository!" });


            IEnumerable<TouristRouteDTO> touristRouteDto = mapper.Map<IEnumerable<TouristRouteDTO>>(touristRoutesFromRepo);
            return Ok(touristRouteDto);
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]//jwt token
        [Authorize(Roles = JwtClaimRoles.AdminRole)]//only Admin has permission to create a tourist route
        public async Task<IActionResult> CreateTouristRoute([FromBody] NewTouristRouteDTO newTouristRouteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TouristRoute newTouristRoute = mapper.Map<TouristRoute>(newTouristRouteDto);
            touristRouteRepository.AddTouristRoute(newTouristRoute);
            if (await touristRouteRepository.SaveAsync())
            {
                TouristRouteDTO touristRouteDtoToReturn = mapper.Map<TouristRouteDTO>(newTouristRoute);
                return CreatedAtAction("GetTouristRouteById", new { id = touristRouteDtoToReturn.Id }, touristRouteDtoToReturn);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);

        }


        [HttpPatch("{touristRouteId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]//jwt token
        [Authorize(Roles = JwtClaimRoles.AdminRole)]//only Admin has permission to update a tourist route
        public async Task<IActionResult> PartiallyUpdateTouristRoute([FromRoute] Guid touristRouteId, [FromBody] JsonPatchDocument<UpdateTouristRouteDTO> patchDoc)
        {
            TouristRoute? touristRouteFromRepo = await touristRouteRepository.GetTouristRouteByIdAsync(touristRouteId);
            if (touristRouteFromRepo == null)
                return NotFound(new { err = $"Tourist Route ID {touristRouteId} not found!" });

            UpdateTouristRouteDTO updateTouristRouteDto = mapper.Map<UpdateTouristRouteDTO>(touristRouteFromRepo);

            patchDoc.ApplyTo(updateTouristRouteDto, ModelState);

            if (!TryValidateModel(updateTouristRouteDto))
                return BadRequest(ModelState);


            mapper.Map(updateTouristRouteDto, touristRouteFromRepo);
            touristRouteFromRepo.Id = touristRouteId;

            if (await touristRouteRepository.SaveAsync())
                return CreatedAtAction("GetTouristRouteById", new { touristRouteId }, updateTouristRouteDto);


            return BadRequest(new { err = "internal error " });
        }

        [HttpDelete("{touristRouteId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]//jwt token
        [Authorize(Roles = JwtClaimRoles.AdminRole)]//only Admin has permission to delete a tourist route
        public async Task<IActionResult> DeleteTouristRoute([FromRoute] Guid touristRouteId)
        {
            TouristRoute? touristRouteFromRepo = await touristRouteRepository.GetTouristRouteByIdAsync(touristRouteId);
            if (touristRouteFromRepo == null)
                return NotFound(new { err = $"Tourist Route ID {touristRouteId} not found!" });


            touristRouteRepository.DeleteTouristRoute(touristRouteFromRepo);
            if (await touristRouteRepository.SaveAsync())
                return Ok(new { message = "successfully deleted" });

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
