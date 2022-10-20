using SpaceDebris.Web.Interfaces;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class WhyOurWayCTADto : IBaseDtoModel
    {
        public List<SectionsDTO> Sections { get; set; }
        public string GreenGarbageImageUrl { get; set; }
        public string Header { get; set; }
        public string Subheader { get; set; }
        public ButtonCompositionDTO Button { get; set; }

        public WhyOurWayCTADto()
        {

        }
        public WhyOurWayCTADto(WhyOurWayCta whyOurWay)
        {
            Sections = new List<SectionsDTO>();
            foreach (var section in whyOurWay.Sections) { 
                var validDto = new SectionsDTO(section);
                if(validDto.IsValid())
                    Sections.Add(validDto); 
            }
            Button = new ButtonCompositionDTO(whyOurWay.Button.First());
            Header = whyOurWay.Header;
            Subheader = whyOurWay.SubHeader;
            GreenGarbageImageUrl = whyOurWay.GreenGarbageImage.Url().ToString();
        }
        public bool IsValid() 
        { 
            return !string.IsNullOrEmpty(GreenGarbageImageUrl.Trim()) && 
                !string.IsNullOrEmpty(Header.Trim()) &&
                !string.IsNullOrEmpty(Subheader.Trim()) && Button.IsValid(); }
    }
}