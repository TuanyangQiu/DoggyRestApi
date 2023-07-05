using DoggyRestApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DoggyRestApi.Helper
{
    public static class RelatedLinks
    {
        public static List<LinkDTO> GetRelatedLink(this List<LinkDTO> linkDTOs, IUrlHelper url, string routeName, object? obj, string rel, string method)
        {
            ArgumentNullException.ThrowIfNull(linkDTOs, nameof(linkDTOs));

            string? href = url.Link(routeName, obj);
            if (href != null)
                linkDTOs.Add(new LinkDTO(href, rel, method));


            return linkDTOs;
        }
    }
}
