using SpaceDebris.Web.Interfaces;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class TrashServicePageDto : IBaseDtoModel
    {
        public SectionsDTO Section { get; set; }
        public ButtonCompositionDTO Button { get; set; }
        public CreateGarbageFormDto FormRequest { get; set; }
        public TrashServicePageDto()
        {

        }
        public TrashServicePageDto(SectionsDTO sections, ButtonCompositionDTO button)
        {
            Section = sections;
            Button = button;
            FormRequest = new CreateGarbageFormDto();
        }

        public bool IsValid()
        {
            return Section.IsValid() && Button.IsValid();
        }
    }
}