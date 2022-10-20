using SpaceDebris.Web.Interfaces;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class HeaderTextCompositionDto : IBaseDtoModel
    {
        public string Header { get; set; }
        public string SubHeader { get; set; }
        public HeaderTextCompositionDto(string header, string subHeader)
        {
            Header = header;
            SubHeader = subHeader;
        }
        public HeaderTextCompositionDto(HeaderTextsComp headerText)
        {
            Header = headerText.Header;
            SubHeader = headerText.SubHeader;
            
        }
        public bool IsValid() { return !string.IsNullOrEmpty(Header?.Trim()) && !string.IsNullOrEmpty(SubHeader?.Trim()); }
    }
}