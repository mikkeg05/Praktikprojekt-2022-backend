using SpaceDebris.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class ContentPageDTO : IBaseDtoModel
    {
        public ContentPageDTO()
        {

        }
        public ContentPageDTO(TeamMemberSectionDto teamMemberSection, SectionsDTOContentPage aboutUsSection, SectionsListDtoContentPage articles, HeaderSubBtnDto header)
        {
            TeamMemberSection = teamMemberSection;
            AboutUsSection = aboutUsSection;
            Articles = articles;
            Header = header;
        }
        public HeaderSubBtnDto Header { get; set; }
        public SectionsDTOContentPage AboutUsSection { get; set; }
        public SectionsListDtoContentPage Articles { get; set; }
        public TeamMemberSectionDto TeamMemberSection { get; set; }
     
        public bool IsValid() { 
            return Header.IsValid() && 
                AboutUsSection.IsValid() && 
                TeamMemberSection.IsValid(); }
    }
}