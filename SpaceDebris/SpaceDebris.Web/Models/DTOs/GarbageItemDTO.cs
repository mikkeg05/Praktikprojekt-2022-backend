using SpaceDebris.Web.Interfaces;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class GarbageItemDTO : IBaseDtoModel
    {
        public float Weight { get; set; }
        public float Length { get; set; }
        public float Depth { get; set; }
        public float Width { get; set; }
        public float CombinedSize => Width * Length * Depth;
        public float Price => (CombinedSize / 100000) * Weight;
        public string Status { get; set; }


        public GarbageItemDTO()
        {

        }
        public GarbageItemDTO(GarbageItem garbageItem)
        {
            Weight = float.Parse(garbageItem.Weight.ToString());
            Length = float.Parse(garbageItem.Length.ToString());
            Depth = float.Parse(garbageItem.Depth.ToString());
            Width  = float.Parse(garbageItem.Width.ToString());
            Status = garbageItem.Status;
        }

        public bool IsValid() 
        {
            return !string.IsNullOrEmpty(Weight.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(Length.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(Depth.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(Width.ToString()?.Trim());
        }
    }
    public class GarbageItemM3DTO : IBaseDtoModel
    { 
        public float Weight { get; set; }
        public float M3 { get; set; }
        public string Status { get; set; }
        public float Price => (M3 / 100000) * Weight;
        public GarbageItemM3DTO()
        {

        }
    
        public GarbageItemM3DTO(GarbageItemM3 garbageItem) 
        {
            Weight = float.Parse(garbageItem.Weight.ToString());
            M3 = float.Parse(garbageItem.M3.ToString());
            Status = garbageItem.Status;
        }
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Weight.ToString()?.Trim()) && !string.IsNullOrEmpty(M3.ToString()?.Trim());
        }
    }
    public class GarbageItemOrderDto 
    {
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public string UserNameAndDate { get; set; }
        public decimal Price { get; set; }
        public GarbageItemOrderDto(GarbageItem garbage)
        {
            Quantity = 1;
            ItemName = "Trash pickup order";
            Price = garbage.Price;
            UserNameAndDate = garbage.Name;
        }
        public GarbageItemOrderDto(GarbageItemM3 garbage)
        {
            Quantity = 1;
            ItemName = "Trash pickup order";
            Price = garbage.Price;
            UserNameAndDate = garbage.Name;
        }
    }
}