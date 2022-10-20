using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class TrashBagSectionDto
    {
        public List<TrashBagDTO> Bags { get; set; }
        public string BagsHeader { get; set; }
        public string BagsSubheader { get; set; }
        public TrashBagSectionDto()
        {

        }
        public TrashBagSectionDto(WebshopTrashBags bagSection)
        {
            Bags = new List<TrashBagDTO>();
            
            foreach(var bag in bagSection.TrashBag) 
            {
                var validDto = new TrashBagDTO(bag);
                if (validDto.IsValid())
                    Bags.Add(validDto); }
            BagsHeader = bagSection.Header;
            BagsSubheader = bagSection.SubHeader;
        }
    }
}