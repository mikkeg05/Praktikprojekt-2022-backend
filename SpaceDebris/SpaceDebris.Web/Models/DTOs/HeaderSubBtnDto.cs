using SpaceDebris.Web.Interfaces;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class HeaderSubBtnDto : IBaseDtoModel
    {
        public string Title { get; set; }
        public string Subheader { get; set; }
        
        public ButtonCompositionDTO Button { get; set; }
        public HeaderSubBtnDto()
        {

        }
        public HeaderSubBtnDto(HeaderSubheaderButton headersubheader)
        {
            Title = headersubheader.Header;
            Subheader = headersubheader.SubHeader;
            if(headersubheader.Button.Count() > 0)
                Button = new ButtonCompositionDTO(headersubheader.Button.First());
        }
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Title?.Trim()) &&
                   !string.IsNullOrEmpty(Subheader?.Trim()) &&
                   Button.IsValid();
        ;
        }
    }
}