using DoggyRestApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlTypes;

namespace DoggyRestApi.Helper
{
    public static class RelatedLinks
    {
        private static List<string> acceptableHttpMethods = new List<string> { "GET",
                                                                               "PUT",
                                                                               "POST",
                                                                               "DELETE",
                                                                               "HEAD",
                                                                               "OPTIONS",
                                                                               "TRACE",
                                                                               "PATCH",
                                                                               "CONNECT" };

        public static List<LinkDTO> GetRelatedLink(this List<LinkDTO> linkDTOs, string? href, string rel, string httpMethod)
        {
            ArgumentNullException.ThrowIfNull(linkDTOs, nameof(linkDTOs));

            //href validation
            if (!Uri.TryCreate(href, UriKind.Absolute, out var uriResult) ||
                (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
            {
                throw new ArgumentException("Invalid url format", nameof(href));
            }

            //rel validation
            if (string.IsNullOrWhiteSpace(rel))
                throw new ArgumentNullException(nameof(rel));

            //http method validation
            if (string.IsNullOrWhiteSpace(httpMethod) || !acceptableHttpMethods.Contains(httpMethod.ToUpper()))
                throw new ArgumentException("Invalid http method", nameof(httpMethod));

            linkDTOs.Add(new LinkDTO(href!, rel, httpMethod));

            return linkDTOs;
        }
    }
}
