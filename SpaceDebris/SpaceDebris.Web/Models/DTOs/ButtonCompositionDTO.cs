using SpaceDebris.Web.Interfaces;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class ButtonCompositionDTO : IBaseDtoModel
    {
        public ButtonCompositionDTO(ButtonList button)
        {
            BtnText = button.ButtonText;
            if(button.ButtonLink != null) { BtnLink = button.ButtonLink.Url().ToString(); }
                
            BtnColor = button.ButtonColor.ToString();
        }
        public ButtonCompositionDTO()
        {

        }

        public string BtnText { get; set; }
        public string BtnLink { get; set; }
        public string BtnColor { get; set; }

        public ButtonCompositionDTO(string btnText, string btnLink, string btnColor)
        {
            BtnText = btnText;
            BtnLink = btnLink;
            BtnColor = btnColor;
        }
        public bool IsValid() {
            return !string.IsNullOrEmpty(BtnText.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(BtnLink.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(BtnColor.ToString()?.Trim());
        }
    }
}