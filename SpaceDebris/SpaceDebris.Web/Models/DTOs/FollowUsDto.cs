using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class FollowUsDto
    {
        public List<LinkDtoFromFooter> Links { get; set; }

        public FollowUsDto(FollowUs follow)
        {
            Links = new List<LinkDtoFromFooter>();
            foreach (var item in follow.Socials)
            {
                Links.Add(new LinkDtoFromFooter((Footer)item));
            }
        }
    }
    public class FollowUsDto2
    { 
        public List<LinkDto> Links { get; set; }
        public FollowUsDto2(FollowUs followUs)
        {
            Links = new List<LinkDto>();
            foreach(var item in followUs.Socials) { Links.Add(new LinkDto((Footer)item)); }
        }
    }
}