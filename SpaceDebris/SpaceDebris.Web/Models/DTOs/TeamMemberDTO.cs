using SpaceDebris.Web.Interfaces;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    
    public class TeamMemberDTO : IBaseDtoModel
    {
        public TeamMemberDTO()
        {

        }
        public TeamMemberDTO(TeamMember teamMember)
        {
            TeamMemberName = teamMember.TeamMemberName;
            JobTitle = teamMember.TeamMemberTitle;
            Description = teamMember.TeamMemberDescription;
            TeamMemberImage = teamMember.TeamMemberImage.Url().ToString();
            Id = teamMember.Key.ToString();
        }

        public string TeamMemberImage { get; set; }
        public string TeamMemberName { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
       public bool IsValid()
       {
            return !string.IsNullOrEmpty(TeamMemberName.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(JobTitle.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(TeamMemberImage.ToString()?.Trim()) &&
                !string.IsNullOrEmpty(Description.ToString()?.Trim());
       } 
        
    }
   
}