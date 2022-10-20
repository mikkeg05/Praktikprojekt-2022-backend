using SpaceDebris.Web.Business;
using SpaceDebris.Web.Business.HelperMethods;
using SpaceDebris.Web.Business.PageMethods;
using SpaceDebris.Web.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Umbraco.Core.Services;
using Umbraco.Web.WebApi;

namespace SpaceDebris.Web.Controllers
{

    //umbraco/api/[endpoint]
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class EndpointController : UmbracoApiController
    {
        private readonly IContentService _contentService;
        private readonly PageHelper _pageHelper;
        private readonly WebshopMethods _webshopMethods;
        private readonly ContentService  _contentServiceMethods;
        private readonly CreateGarbageFormDto _createGarbageFormDto;


        public EndpointController() { }

        public EndpointController(IContentService contentService)
        {
            _pageHelper = new PageHelper(_contentService);
            _webshopMethods = new WebshopMethods();
            _contentService = contentService;
            _contentServiceMethods = new ContentService(_contentService);
            _createGarbageFormDto = new CreateGarbageFormDto();
        }
      

        [HttpGet]
        [Route("Contentpage")]
        public IHttpActionResult GetContentPage()
        {
            return Ok(_contentServiceMethods.GetContentPage());
        }
        [HttpGet]
        [Route("Webshoppage")]
        public IHttpActionResult GetWebshopPage()
        {
            return Ok(_contentServiceMethods.GetWebShopPage());
        }        
        [HttpGet]
        [Route("Frontpage")]
        public IHttpActionResult GetFrontpage()
        {
            return Ok(_contentServiceMethods.GetFrontpage());
        }
        [HttpPost]
        [Route("garbageItemPost")]
        public IHttpActionResult GarbageItemPost(GarbageFormRequest request) 
        {
            
            return Ok(_contentServiceMethods.CreateGarbageItem(request));
        } 
        [HttpPost]
        [Route("garbageItemPostM3")]
        public IHttpActionResult GarbageItemPostM3(GarbageM3Request request) 
        {
            return Ok(_contentServiceMethods.CreateM3Garbage(request));
        }
        [HttpPost]
        [Route("updateStatus")]
        public IHttpActionResult UpdateStatus(UpdateStatusRequestModel request) 
        {
            return Ok(_contentServiceMethods.UpdateStatus(request.Ordername, request.Status));
        }
        [HttpGet]
        [Route("getOrders")]
        public IHttpActionResult GetOrders()
        {
            return Ok(_contentServiceMethods.GetOrders());
        }
        [HttpGet]
        [Route("getTrashServicePage")]
        public IHttpActionResult GetTrashServicePage()
        {
            return Ok(_contentServiceMethods.GetTrashServicePage());
        }
        [HttpGet]
        [Route("getNavigationHeader")]
        public IHttpActionResult GetNavigationHeader()
        {
            return Ok(_contentServiceMethods.GetNavigationHeader());
        }
        [HttpGet]
        [Route("getFooter")]
        public IHttpActionResult GetFooter()
        {
            return Ok(_contentServiceMethods.GetFooter());
        }
        [HttpPost]
        [Route("getReceiptPage")]
        public IHttpActionResult GetReceiptPage(ReceiptPageRequestModel request)
        {
            return Ok(_contentServiceMethods.getReceiptByKey(request.Id));
        }
        //[HttpGet]
        //[Route("test")]
        //public IHttpActionResult test()
        //{
        //    _contentServiceMethods.test();
        //    return Ok();
        //}
    }
}