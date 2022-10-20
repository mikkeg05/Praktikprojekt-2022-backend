using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class ReceiptPageDto
    {
        public WeightOrderDto Weights { get; set; }
        public TrashBagOrderDto SmallBags{ get; set; }
        public TrashBagOrderDtoM MediumBags { get; set; }
        public TrashBagOrderDtoL LargeBags { get; set; }
        public ReceiptDto Text { get; set; }
        public GarbageItemOrderDto GarbageItem { get; set; }
        
        public decimal TotalPrice => Weights.Price + SmallBags.Price + MediumBags.Price + LargeBags.Price + GarbageItem.Price;
        public ReceiptPageDto(WeightOrderDto weights, TrashBagOrderDto smallBags, TrashBagOrderDtoM mediumBags, TrashBagOrderDtoL largeBags, ReceiptDto text, GarbageItemOrderDto order)
        {
            Weights = weights;
            SmallBags = smallBags;
            MediumBags = mediumBags;
            LargeBags = largeBags;
            Text = text;
            GarbageItem = order;
        }
        public ReceiptPageDto(GarbageItem item, ReceiptPage receipt) 
        {
            SmallBags = new TrashBagOrderDto(item);
            MediumBags = new TrashBagOrderDtoM(item);
            LargeBags = new TrashBagOrderDtoL(item);
            Weights = new WeightOrderDto(item);
            GarbageItem = new GarbageItemOrderDto(item);
            Text = new ReceiptDto(receipt);
        }
        public ReceiptPageDto(GarbageItemM3 item, ReceiptPage receipt)
        {
            SmallBags = new TrashBagOrderDto(item);
            MediumBags = new TrashBagOrderDtoM(item);
            LargeBags = new TrashBagOrderDtoL(item);
            Weights = new WeightOrderDto(item);
            GarbageItem = new GarbageItemOrderDto(item);
            Text = new ReceiptDto(receipt);
        }
    }
}