﻿using AutoMapper;
using DoggyRestApi.DTOs;
using DoggyRestApi.Models;
using DoggyRestApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DoggyRestApi.Controllers
{
    [Route("TouristRoutes/{touristRouteId}/Pictures")]
    public class TouristRoutePicturesController : Controller
    {
        private readonly ITouristRouteRepository touristRouteRepository;
        private readonly IMapper mapper;
        public TouristRoutePicturesController(ITouristRouteRepository touristRouteRepository, IMapper mapper)
        {
            this.touristRouteRepository = touristRouteRepository;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetPicturesByTouristRouteId")]
        public async Task<IActionResult> GetPicturesByTouristRouteId([FromRoute] Guid touristRouteId)
        {
            var touristRoutePictures = await touristRouteRepository.GetPicturesByIdAsync(touristRouteId);
            if (touristRoutePictures?.Count() <= 0)
            {
                return NotFound(new { err = $"Cannot find pictures with Id {touristRouteId} !" });
            }

            ICollection<TouristRoutePictureDTO> touristRoutePictureDto = mapper.Map<ICollection<TouristRoutePictureDTO>>(touristRoutePictures);
            return Ok(touristRoutePictureDto);
        }


        [HttpGet("{pictureId}")]
        public async Task<IActionResult> GetSinglePictureById([FromRoute] Guid touristRouteId, int pictureId)
        {
            TouristRoutePicture? touristRoutePicture = await touristRouteRepository.GetSinglePictureByIdAsync(touristRouteId, pictureId);
            if (touristRoutePicture == null)
                return NotFound(new { err = $"The picture {pictureId} with Tourist Route {touristRouteId} not found!" });


            return Ok(mapper.Map<TouristRoutePictureDTO>(touristRoutePicture));
        }

        [HttpPost]
        public async Task<IActionResult> AddPictures4TouristRoute([FromRoute] Guid touristRouteId, [FromBody] List<NewTouristRoutePictureDTO>? newTouristRoutePicturesDTO)
        {
            if (newTouristRoutePicturesDTO == null || newTouristRoutePicturesDTO.Count <= 0)
            {
                return BadRequest(new { err = "No input picture name" });
            }

            if (!(await touristRouteRepository.IsTouristRouteExistAsync(touristRouteId)))
            {
                return NotFound(new { err = $"Tourist Route ID {touristRouteId} not found!" });
            }

            if (newTouristRoutePicturesDTO.Any(i => string.IsNullOrWhiteSpace(i.PictureName)))
            {
                return BadRequest(new { err = $"PictureName cannot be empty!" });
            }

            var touristRoutePicture = mapper.Map<List<TouristRoutePicture>>(newTouristRoutePicturesDTO);
            await touristRouteRepository.AddTouristRoutePictures(touristRouteId, touristRoutePicture);
            if (touristRouteRepository.Save())
            {
                return CreatedAtRoute(nameof(GetPicturesByTouristRouteId), new { touristRouteId = touristRouteId }, touristRoutePicture);
            }


            return BadRequest(new { err = "internal error " });
        }


    }
}
