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
    public class FooterDto : IBaseDtoModel
    {
        public FollowUsDto2 NavigationSection { get; set; }
        public LinkDtoFromFooter AddressSection { get; set; }
        public FollowUsDto2 FollowUsSection { get; set; }
        public string ContactUs { get; set; }
        public string ContactInfo { get; set; }

        public FooterDto(SettingsPage settings)
        {
            if (settings.LeftSideLinks != null)
                NavigationSection = new FollowUsDto2(settings.LeftSideLinks.OfType<FollowUs>().First());
            if (settings.TitleAndLinks != null)
                AddressSection = new LinkDtoFromFooter(settings.TitleAndLinks.FirstOrDefault());
            if (settings.RightSide != null)
            {
                FollowUsSection = new FollowUsDto2(settings.RightSide.OfType<FollowUs>().First());
                ContactUs = settings.RightSide.FirstOrDefault().Value("header").ToString();
                ContactInfo = settings.RightSide.FirstOrDefault().Value("subHeader").ToString();
            }
        }
        public bool IsValid()
        {
            return AddressSection.IsValid() && !string.IsNullOrEmpty(ContactUs?.Trim()) && !string.IsNullOrEmpty(ContactInfo?.Trim());
        }
    }
    public class FooterDto2
    {
        public List<LinkDto> Links { get; set; }
    }
}