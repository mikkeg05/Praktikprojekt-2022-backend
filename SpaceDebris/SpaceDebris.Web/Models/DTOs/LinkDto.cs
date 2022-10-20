using SpaceDebris.Web.Interfaces;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class LinkDto
    {
        public string Link { get; set; }
        public string LinkName { get; set; }
        public string Icon { get; set; }
        public LinkDto(Footer footer) 
        { 
            foreach(var item in footer.FooterLinks) 
            {
                Link = item.Url.ToString();
                LinkName = item.Name;
            }
        }

        public LinkDto(string link, string linkName)
        {
            Link = link;
            LinkName = linkName;
        }
    }
    public class LinkDtoFromFooter : IBaseDtoModel
    {
        public List<string> Link { get; set; }
        public List<string> LinkNames { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public List<string> Id { get; set; }
        public LinkDtoFromFooter(Footer footer)
        {
            Link = new List<string>();
            foreach(var link in footer.FooterLinks) { Link.Add(link.Url.ToString()); }
            LinkNames = new List<string>();
            foreach(var linkNames in footer.FooterLinks) { LinkNames.Add(linkNames.Name); }
            Text = footer.Title;
          //  foreach (var keys in footer.FooterLinks) { Id.Add(keys.Key.ToString()); }
            if (footer.Image != null)
                Icon = footer.Image.Url().ToString();
            
        }
        public bool IsValid() {
            return 
                !string.IsNullOrEmpty(Icon.ToString()?.Trim()) && 
                !(Link.Count > 0) && 
                !(LinkNames.Count > 0);
        }
    }
}