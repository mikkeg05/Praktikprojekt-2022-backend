using SpaceDebris.Web.Interfaces;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class SectionsDTO : IBaseDtoModel
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public SectionsDTO()
        {

        }

        public SectionsDTO(Section section)
        {
            ImageUrl = section.Image.Url().ToString();
            Title = section.Title;
            Body = section.Body;
        }

        public bool IsValid() => !string.IsNullOrEmpty(ImageUrl?.Trim()) && !string.IsNullOrEmpty(Title?.Trim());
    }
}