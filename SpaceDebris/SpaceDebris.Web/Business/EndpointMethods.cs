using SpaceDebris.Web.Business.HelperMethods;
using SpaceDebris.Web.Models.DTOs;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace SpaceDebris.Web.Business
{
    public class EndpointMethods
    {
        private readonly IContentService _contentService;
        private static UmbracoContext UmbracoContext => Umbraco.Web.Composing.Current.UmbracoContext;
        private PageHelper _pageHelper;

        public EndpointMethods(PageHelper pageHelper)
        {
            _pageHelper = pageHelper;
        }

        public EndpointMethods()
        {
        }
      
    }
}
