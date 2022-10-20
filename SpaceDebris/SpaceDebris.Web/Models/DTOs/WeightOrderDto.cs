using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class WeightOrderDto
    {
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string ItemType { get; set; }

        public WeightOrderDto(GarbageItem garbage)
        {
            Price = 0;
            if (garbage.WeightForSale != null)
            {
                foreach (var item in garbage.WeightForSale)
                {
                    Quantity++;
                    Price += item.Price;

                }
                ItemName = "SD Weight";
                ItemType = "item";
            }
        }
        public WeightOrderDto(GarbageItemM3 garbage)
        {
            Price = 0;
            if (garbage.WeightForSale != null)
            {
                foreach (var item in garbage.WeightForSale)
                {
                    Quantity++;
                    Price += item.Price;

                }
                ItemName = "SD Weight";
                ItemType = "item";
            }
        }
    }
}