using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs 
{
    public class weightJsonDto : JsonDtoBase
    {
        public string button { get; set; }
        public List<Dictionary<string, object>> cartIcon { get; set; }
        public List<Dictionary<string, object>> image { get; set; }
        public string key { get; set; }
        public string description { get; set; }
        public string descriptionTitle { get; set; }
        public decimal price { get; set; }
        public string title { get; set; }
        public string typeOfItem { get; set; }
        public decimal weightId { get; set; }

        public weightJsonDto(WeightForSale weight)
        {
            button = null;
            cartIcon = new List<Dictionary<string, object>>();
            image = new List<Dictionary<string, object>>();
            var dic = new Dictionary<string, object>();
            var dic2 = new Dictionary<string, object>();
            if(weight.CartIcon != null)
            {
                dic.Add("key", weight.CartIcon.Key);
                dic.Add("mediaKey", weight.CartIcon.MediaItem.Key);
            }
            if(weight.Image != null)
            { dic2.Add("key", weight.Image.Key);dic2.Add("mediaKey", weight.Image.MediaItem.Key); }
            cartIcon.Add(dic);
            image.Add(dic2);
            key = weight.Key.ToString();
            Name = $"{weight.Title}";
            Alias = weight.ContentType.Alias;
            description = weight.Description.ToString();
            descriptionTitle = weight.DescriptionTitle;
            price = weight.Price;
            title = weight.Title;
            typeOfItem = weight.TypeOfItem;
            weightId = weight.WeightId;
        }
    }
}