using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class SectionsListDto 
    {
        public List<SectionsDTO> Sections { get; set; }
        public SectionsListDto()
        {

        }
        public SectionsListDto(SectionListNested sectionsList)
        {
            Sections = new List<SectionsDTO>();
            foreach (var section in sectionsList.SectionList)
            {
                var sections = new SectionsDTO(section);
                if (sections.IsValid())
                    Sections.Add(sections);
            }
        }
        
    }
    public class SectionsListDtoContentPage 
    {
        public List<SectionsDTOContentPage> Sections { get; set; }
        public SectionsListDtoContentPage()
        {

        }
        public SectionsListDtoContentPage(SectionListNested sectionsList)
        {
            Sections = new List<SectionsDTOContentPage>();
            foreach (var section in sectionsList.SectionList)
            {
                var sections = new SectionsDTOContentPage(section);
                if (sections.IsValid())
                    Sections.Add(sections);
            }
        }

    }
}