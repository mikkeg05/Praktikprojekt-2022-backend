using SpaceDebris.Web.Interfaces;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class TrashBagDTO : IBaseDtoModel
    {
        public string TrashBagImageUrl { get; set; }
        public string Size { get; set; }
        public float Price { get; set; }
        public string Measurements { get; set; }
        public string IconUrl { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string ItemType { get; set; }
        
        public TrashBagDTO (TrashBagItem trashBagItem) 
        {
            TrashBagImageUrl = trashBagItem.Image.Url().ToString();
            Size = trashBagItem.Size;
            Price = trashBagItem.Price;
            Measurements = trashBagItem.Measurements;
            IconUrl = trashBagItem.CartIcon.Url().ToString();
            Id = int.Parse(trashBagItem.BagId.ToString());
            Title = trashBagItem.Title;
            ItemType = trashBagItem.TypeOfItem;
        }

        public TrashBagDTO()
        {

        }

        public bool IsValid() { 
            return !string.IsNullOrEmpty(TrashBagImageUrl?.Trim()) &&
                   !string.IsNullOrEmpty(Size?.Trim()) &&
                   !string.IsNullOrEmpty(Price.ToString()?.Trim()) &&
                   !string.IsNullOrEmpty(Measurements?.Trim()) &&
                   !string.IsNullOrEmpty(Title?.Trim()) &&
                   !string.IsNullOrEmpty(ItemType?.Trim()) 
                   && !string.IsNullOrEmpty(IconUrl?.Trim()) 
        ; }
    }
}