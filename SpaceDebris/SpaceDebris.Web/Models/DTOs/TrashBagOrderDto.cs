using SpaceDebris.Web.Models.ModelsBuilder;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class TrashBagOrderDto
    {
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string ItemType { get; set; }
        public TrashBagOrderDto()
        {

        }
        public TrashBagOrderDto(GarbageItem garbage)
        {
            if (garbage.TrashBagList != null)
            {
                foreach (var item in garbage.TrashBagList)
                {
                    if (item.Size.ToLower() == "small")
                    {
                        Quantity++;
                        Price += item.Price;
                    }
                }
                ItemName = "SD INC bag Small";
            }
        }
        public TrashBagOrderDto(GarbageItemM3 garbage)
        {

            if (garbage.TrashBagList != null)
            {
                foreach (var item in garbage.TrashBagList)
                {
                    if (item.Size.ToLower() == "small")
                    {
                        Quantity++;
                        Price += item.Price;
                    }
                }
                ItemName = "SD INC bag Small";
            }
        }
    }
    public class TrashBagOrderDtoM
    {

        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string ItemType { get; set; }

        public TrashBagOrderDtoM(GarbageItem garbage)
        {

            if (garbage.TrashBagList != null)
            {
                foreach (var item in garbage.TrashBagList)
                {
                    if (item.Size.ToLower() == "medium")
                    {
                        Quantity++;
                        Price += item.Price;
                    }
                }
                ItemName = "SD INC bag Medium";
                ItemType = "item";
            }
        }
        public TrashBagOrderDtoM(GarbageItemM3 garbage)
        {

            if (garbage.TrashBagList != null)
            {
                foreach (var item in garbage.TrashBagList)
                {
                    if (item.Size.ToLower() == "medium")
                    {
                        Quantity++;
                        Price += item.Price;
                    }
                }
                ItemName = "SD INC bag Medium";
                ItemType = "item";
            }
        }

    }
    public class TrashBagOrderDtoL
    {
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string ItemType { get; set; }

        public TrashBagOrderDtoL(GarbageItem garbage)
        {

            if (garbage.TrashBagList != null)
            {
                foreach (var item in garbage.TrashBagList)
                {
                    if (item.Size.ToLower() == "large")
                    {
                        Quantity++;
                        Price += item.Price;
                    }
                }
                ItemName = "SD INC bag Large";
                ItemType = "item";
            }
        }
        public TrashBagOrderDtoL(GarbageItemM3 garbage)
        {

            if (garbage.TrashBagList != null)
            {
                foreach (var item in garbage.TrashBagList)
                {
                    if (item.Size.ToLower() == "large")
                    {
                        Quantity++;
                        Price += item.Price;
                    }
                }
                ItemName = "SD INC bag Large";
                ItemType = "item";
            }
        }
    }
}