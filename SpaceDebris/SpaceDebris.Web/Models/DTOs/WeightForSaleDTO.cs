using SpaceDebris.Web.Interfaces;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class WeightForSaleDTO : IBaseDtoModel
    {
        public string WeightImageUrl { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public string DescriptionTitle { get; set; }
        public string Description { get; set; }
        public ButtonCompositionDTO Button { get; set; }
        public string CartIconUrl { get; set; }
        public int Id { get; set; }
        public string ItemType { get; set; }
        public WeightForSaleDTO(WeightForSale weightForSale)
        {
            WeightImageUrl = weightForSale.Image.Url().ToString();
            Title = weightForSale.Title;
            Price = (float)weightForSale.Price;
            Description = weightForSale.Description;
            DescriptionTitle = weightForSale.DescriptionTitle;
            if(weightForSale.Button.Count() > 0)
                Button = new ButtonCompositionDTO(weightForSale.Button.First());
            CartIconUrl = weightForSale.CartIcon.Url().ToString();
            Id = int.Parse(weightForSale.WeightId.ToString());
            ItemType = weightForSale.TypeOfItem;
        }

        public WeightForSaleDTO()
        {

        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(WeightImageUrl.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(Title.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(Price.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(Description.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(CartIconUrl.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(Id.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(ItemType.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(DescriptionTitle.ToString()?.Trim())
                && Button.IsValid();
        }
    }
    //public class WeightOrderDto
    //{
    //    public string WeightImageUrl { get; set; }
    //    public string Title { get; set; }
    //    public float Price { get; set; }
    //    public string DescriptionTitle { get; set; }
    //    public string Description { get; set; }
    //    public ButtonCompositionDTO Button { get; set; }
    //    public string CartIconUrl { get; set; }
    //    public int Id { get; set; }
    //    public string ItemType { get; set; }
    //    public WeightForSaleDTO(WeightForSale weightForSale)
    //    {
    //        WeightImageUrl = weightForSale.Image.Url().ToString();
    //        Title = weightForSale.Title;
    //        Price = (float)weightForSale.Price;
    //        Description = weightForSale.Description;
    //        DescriptionTitle = weightForSale.DescriptionTitle;
    //        if (weightForSale.Button.Count() > 0)
    //            Button = new ButtonCompositionDTO(weightForSale.Button.First());
    //        CartIconUrl = weightForSale.CartIcon.Url().ToString();
    //        Id = int.Parse(weightForSale.WeightId.ToString());
    //        ItemType = weightForSale.TypeOfItem;
    //    }
    //}
}