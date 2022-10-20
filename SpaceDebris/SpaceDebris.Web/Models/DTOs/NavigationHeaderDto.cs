using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class NavigationHeaderDto
    {
        public string CartUrl { get; set; }
        public List<LinkDto> LeftSideLinks { get; set; }
        public ButtonCompositionDTO Button { get; set; }
        public string CartIconUrl { get; set; }
        public string LogoIconUrl { get; set; }
        public NavigationHeaderDto()
        {

        }
        public NavigationHeaderDto(SettingsPage settings)
        {
            CartUrl = settings.CartPage.Url().ToString();
            LeftSideLinks = new List<LinkDto>();
            foreach(var item in settings.MainNavigation) { LeftSideLinks.Add(new LinkDto(item.Url.ToString(), item.Name)); }
            //LeftSideLinks = settings.MainNavigation.Select(link => new LinkDto (link.Url.ToString(), link.Name).ToList());  

            if (settings.Button.Count() > 0)
                Button = new ButtonCompositionDTO(settings.Button.First());
            CartIconUrl = settings.CartPage.Url().ToString();
            LogoIconUrl = settings.Logo.Url().ToString();
        }
    }
}