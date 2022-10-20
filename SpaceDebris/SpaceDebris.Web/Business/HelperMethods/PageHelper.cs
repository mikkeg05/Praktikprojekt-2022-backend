using SpaceDebris.Web.Models.DTOs;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace SpaceDebris.Web.Business.HelperMethods
{
    public class PageHelper
    {
        private readonly IContentService _contentService;
        private static UmbracoContext UmbracoContext => Umbraco.Web.Composing.Current.UmbracoContext;
        public PageHelper() { }
        public  PageHelper(IContentService contentService) { _contentService = contentService; }
        public static Frontpage GetFrontPage()
        {

            var page = UmbracoContext.Content.GetAtRoot().FirstOrDefault();
            if (page == null)
                return null;
            Frontpage frontpage = (Frontpage)page;

            if (frontpage == null)
                return null;

            return frontpage;
        }
        public static IPublishedContent GetPage(string pageAlias)
        {
            var frontPage = GetFrontPage();
            if (frontPage == null)
                return null;
            
            var page = frontPage.Children.FirstOrDefault(x => x.ContentType.Alias.Equals(pageAlias, StringComparison.OrdinalIgnoreCase));

            return page;

        }
        public static T CastToDto<T>(IPublishedElement element) where T : class
        {
            var underlyingType = typeof(T);
            if (underlyingType == null)
                return null;
            return (T)Convert.ChangeType(element, underlyingType);
        }

        public static object CastToDto(IPublishedElement element)
        {
            string alias = element.ContentType.Alias;

            switch (alias)
            {
                case "howItWorksCTA":
                    return new HowItWorksCTADto((HowItWorksCta)element);
                case "whyOurWayCTA":
                    return new WhyOurWayCTADto((WhyOurWayCta)element);
                case "imgTextBtn":
                    return new ImgTextBtnDTO((ImgTextBtn)element);
                case "headerSubheaderButton":
                    return new HeaderSubBtnDto((HeaderSubheaderButton)element);
                case "sectionListNested":
                    return new SectionsListDto((SectionListNested)element);
                case "teamMemberSection":
                    return new TeamMemberSectionDto((TeamMemberSection)element);
                case "section":
                    return new SectionsDTO((Section)element);
                case "buttonList":
                    return new ButtonCompositionDTO((ButtonList)element);
                case "weightForSale":
                    return new WeightForSaleDTO((WeightForSale)element);
                case "webshopTrashBags":
                    return new TrashBagSectionDto((WebshopTrashBags)element);
                case "footer":
                    return new LinkDtoFromFooter((Footer)element);
                default: break;
            }
            return null;
        }
        public static object CastToSectionPageDTO(IPublishedElement element)
        {
            string alias = element.ContentType.Alias;
            switch (alias) 
            {
                case "section":
                    return new SectionsDTOContentPage((Section)element);
                case "sectionListNested":
                    return new SectionsListDtoContentPage((SectionListNested)element);
            }
            return null;
        }
    }
}