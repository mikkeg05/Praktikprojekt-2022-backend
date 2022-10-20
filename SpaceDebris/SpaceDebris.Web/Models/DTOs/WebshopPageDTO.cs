using Newtonsoft.Json;
using SpaceDebris.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class WebshopPageDTO : IBaseDtoModel
    {
        public ImgTextBtnDTO TopSection { get; set; }
        public TrashBagSectionDto TrashBagSection { get; set; }
        public WeightForSaleDTO Weight { get; set; }

        public WebshopPageDTO(ImgTextBtnDTO topSection, TrashBagSectionDto trashBagSection, WeightForSaleDTO weight)
        {
            TopSection = topSection;
            TrashBagSection = trashBagSection;
            Weight = weight;
        }

        public bool IsValid()
        {
            return TopSection.IsValid() && Weight.IsValid();
           
        }
    }
}