﻿namespace DoggyRestApi.DTOs
{
    public class TouristRoutePictureDTO
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;

        public Guid TouristRouteId { get; set; }
    }
}
