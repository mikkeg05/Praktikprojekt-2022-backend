using SpaceDebris.Web.Interfaces;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;

namespace SpaceDebris.Web.Models.DTOs
{
    public class HowItWorksCTADto : IBaseDtoModel
    {
        public List<SectionsDTO> Sections { get; set; }

        public ButtonCompositionDTO Button { get; set; }

        public string Header { get; set; }
        public string SubHeader { get; set; }

        public HowItWorksCTADto(HowItWorksCta howItWorks)
        {
            Sections = new List<SectionsDTO>();
            foreach (var section in howItWorks.Sections)
            {
                var validDto = new SectionsDTO(section);
                if(validDto.IsValid())
                    Sections.Add(validDto);
            }
            Button = new ButtonCompositionDTO(howItWorks.Button.First());
            Header = howItWorks.Header;
            SubHeader = howItWorks.SubHeader;
        }

        public HowItWorksCTADto(List<SectionsDTO> sectionsDTOs, ButtonCompositionDTO buttonCompositionDTO, string header, string subheader)
        {
            Sections = sectionsDTOs;
            Button = buttonCompositionDTO;
            Header = header;
            SubHeader = subheader;
        }

        public HowItWorksCTADto()
        {
        }
        public bool IsValid() { return !string.IsNullOrEmpty(Header?.Trim()) && !string.IsNullOrEmpty(SubHeader?.Trim()) && Button.IsValid(); }
    }
}