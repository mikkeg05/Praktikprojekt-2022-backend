using SpaceDebris.Web.Interfaces;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class TeamMemberSectionDto : IBaseDtoModel
    {
        public string Header { get; set; }
        public string Subheader { get; set; }
        public List<TeamMemberDTO> TeamMemberList { get; set; }
         public TeamMemberSectionDto()
        {

        }
        public TeamMemberSectionDto(TeamMemberSection teamMemberSection)
        {
            TeamMemberList = new List<TeamMemberDTO>();
            foreach (var item in teamMemberSection.TeamMember)
            {
                var member = new TeamMemberDTO(item);
                if (member.IsValid())
                    TeamMemberList.Add(member);
            }
            Header = teamMemberSection.Header;
            Subheader = teamMemberSection.SubHeader;
        }
        public bool IsValid() {
            return !string.IsNullOrEmpty(Header.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(Subheader.ToString()?.Trim());
               
        }
    }
}