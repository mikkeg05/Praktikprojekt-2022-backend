using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class ReceiptDto
    {   
        public string Logo { get; set; }
        public string Title { get; set; }
        public string BillingInfo { get; set; }
        public string Total { get; set; }
        public string OrderSummary { get; set; }
        public ReceiptDto(ReceiptPage receipt)
        {
            Logo = receipt.Image.Url().ToString();
            Title = receipt.Title;
            BillingInfo = receipt.BillingInfo;
            Total = receipt.Header;
            OrderSummary = receipt.OrderSummary;
        }

    }
}