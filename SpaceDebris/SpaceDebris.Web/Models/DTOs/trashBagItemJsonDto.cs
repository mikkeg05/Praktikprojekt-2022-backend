using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Composing;
using Umbraco.Core.Services.Implement;

namespace SpaceDebris.Web.Models.DTOs
{
    public class trashBagItemJsonDto : JsonDtoBase
    {
        public decimal bagId { get; set; }
        public List<Dictionary<string, object>> cartIcon { get; set; }
        public List<Dictionary<string, object>> image { get; set; }
        public string key { get; set; }
        public string measurements { get; set; }
        public int price { get; set; }
        public string size { get; set; }
        public string title { get; set; }
        public string typeOfItem { get; set; }


        public trashBagItemJsonDto(TrashBagItem Trash)
        {
            bagId = Trash.BagId;
            cartIcon = new List<Dictionary<string, object>>();
            image = new List<Dictionary<string, object>>();
            var dic = new Dictionary<string, object>();
            var dic2 = new Dictionary<string, object>();
            if (Trash.CartIcon != null)
            {
                dic.Add("key", Trash.CartIcon.Key);
                dic.Add("mediaKey", Trash.CartIcon.MediaItem.Key);
            }
            cartIcon.Add(dic);
            if(Trash.Image != null)
            {
                dic2.Add("key", Trash.Image.Key);
                dic2.Add("mediaKey", Trash.Image.MediaItem.Key);
            }
            image.Add(dic2);
            key = Trash.Key.ToString();
            measurements = Trash.Measurements.ToString();
            Name = $"{Trash.Size} bag";//.GetProperty("name").ToString();
            Alias = Trash.ContentType.Alias;
            price = Trash.Price;
            size = Trash.Size;
            title = Trash.Title;
            typeOfItem = Trash.TypeOfItem;
        }
    }
}