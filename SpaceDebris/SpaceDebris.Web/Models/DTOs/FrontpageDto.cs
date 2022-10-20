using SpaceDebris.Web.Interfaces;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class FrontpageDto : IBaseDtoModel
    {
        public string VideoUrl { get; set; }
        public HeaderSubBtnDto TopSection { get; set; }
        public HowItWorksCTADto HowItWorks { get; set; }
        public WhyOurWayCTADto WhyOurWay { get; set; }
        public ImgTextBtnDTO BottomSection { get; set; }
        public FrontpageDto(HowItWorksCTADto howItWorksCTADto, WhyOurWayCTADto whyOurWay, ImgTextBtnDTO imgTextBtnDTO, HeaderSubBtnDto headerSubBtnDto, string videoUrl)
        {
            WhyOurWay = whyOurWay;
            HowItWorks = howItWorksCTADto;
            BottomSection = imgTextBtnDTO;
            TopSection = headerSubBtnDto;
            VideoUrl = videoUrl;
        }
        public FrontpageDto()
        {

        }

        public bool IsValid() { 
            return !string.IsNullOrEmpty(VideoUrl?.Trim()) && 
                TopSection.IsValid() && 
                HowItWorks.IsValid() &&
                WhyOurWay.IsValid() &&
                BottomSection.IsValid(); }

    }
}