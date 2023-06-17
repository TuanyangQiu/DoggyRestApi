﻿using DoggyRestApi.Models;
using System.ComponentModel.DataAnnotations;

namespace DoggyRestApi.DTOs
{
    public class TouristRouteDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        //Price = TouristRoute.OriginalPrice * TouristRoute.DiscountPercent
        public decimal Price { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DepartureTime { get; set; }

        public string Features { get; set; }
        public string Fees { get; set; }
        public string Notes { get; set; }


        public double? Rating { get; set; }

        public string? TravelDays { get; set; }

        public string? TripType { get; set; }

        public string? DepartureCity { get; set; }

        public ICollection<TouristRoutePictureDTO> TouristRoutePictures { get; set; }
    }
}
