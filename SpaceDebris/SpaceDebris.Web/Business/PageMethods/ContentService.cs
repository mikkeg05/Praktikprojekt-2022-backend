using System.Text.Json;
using SpaceDebris.Web.Business.HelperMethods;
using SpaceDebris.Web.Models.DTOs;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;
using Umbraco.Web;
using System.Dynamic;
using System.Reflection;
using SpaceDebris.Web.Extentions;
using System.Web.Helpers;
using SpaceDebris.Web.Models;

namespace SpaceDebris.Web.Business.PageMethods
{
    public class ContentService
    {
        private readonly IContentService _contentService;
       // private readonly OrderService _orderService;
        private readonly IPublishedContent _publishedContent;
        public ContentService()
        {

        }
        public ContentService(IContentService contentService)
        {
           // _orderService = new OrderService;
            _contentService = contentService;
        }
        public Guid? CreateGarbageItem(GarbageFormRequest garbageFormRequest)
        {
            WebshopPage webshop = (WebshopPage)PageHelper.GetPage("webshopPage");
            var maxSize = float.Parse(PageHelper.GetPage("settingsPage").GetProperty("garbageMaxCm3").GetValue().ToString());
            var maxWeight = float.Parse(PageHelper.GetPage("settingsPage").GetProperty("garbageMaxWeight").GetValue().ToString());
            GarbageItemDTO garbageItem = new GarbageItemDTO();
            if (garbageFormRequest.GarbageItem != null)
            {
                garbageItem = garbageFormRequest.GarbageItem;
            }
            if (!garbageItem.IsValid())
                return null;
            if (!garbageFormRequest.IsValid())
                return null;
            var fullname = garbageFormRequest.GetName();
            if (maxWeight < garbageItem.Weight || maxSize < garbageItem.CombinedSize)
                return null;

            var content = _contentService.Create(fullname, int.Parse(garbageFormRequest.ParentId), "garbageItem");
            List<TrashBagItem> bags = new List<TrashBagItem>();
            dynamic exObj = new ExpandoObject();
            var rawNC = new Dictionary<string, object>();
            List<TrashBagItem> bagsbetter = new List<TrashBagItem>();
            List<object> weightItems = new List<object>();
            List<object> items = new List<object>();

            foreach (var id in garbageFormRequest.id)
            {
                if (id.ids < 3)
                {

                    WebshopTrashBags bagster = (WebshopTrashBags)webshop.Sections.FirstOrDefault(x => x.ContentType.Alias.Equals("webshopTrashBags"));
                    foreach (TrashBagItem trashBagItem in bagster.TrashBag)
                    {

                        if (trashBagItem.BagId != id.ids)
                            continue;

                        for (int i = 0; i < id.quantity; i++)
                        {
                            items.Add(new trashBagItemJsonDto(trashBagItem));
                        }
                    }
                }
                else if (id.ids == 3)
                {
                    WeightForSale weight = (WeightForSale)webshop.Sections.FirstOrDefault(x => x.ContentType.Alias.Equals("weightForSale"));
                    if (weight.WeightId != id.ids)
                        continue;
                    for (int i = 0; i < id.quantity; i++)
                    {
                        weightItems.Add(new weightJsonDto(weight));
                    }
                }
            }

            var weightNested = weightItems.ToJson();
            var itemsNested = Newtonsoft.Json.JsonConvert.SerializeObject(items);
            content.SetValue("weightForSale", weightNested);
            content.SetValue("trashBagList", itemsNested);
            content.SetValue("weight", garbageItem.Weight);
            content.SetValue("length", garbageItem.Length);
            content.SetValue("depth", garbageItem.Depth);
            content.SetValue("width", garbageItem.Width);
            content.SetValue("price", garbageItem.Price);
            content.SetValue("status", "In pick-up queue...");
            _contentService.SaveAndPublish(content);
            return content.Key;
        }
        public Guid? CreateM3Garbage(GarbageM3Request garbage)
        {
            WebshopPage webshop = (WebshopPage)PageHelper.GetPage("webshopPage");
            var maxSize = float.Parse(PageHelper.GetPage("settingsPage").GetProperty("garbageMaxCm3").GetValue().ToString());
            var maxWeight = float.Parse(PageHelper.GetPage("settingsPage").GetProperty("garbageMaxWeight").GetValue().ToString());
            GarbageItemM3DTO garbageItem = new GarbageItemM3DTO();
            if (garbage.GarbageItem != null)
            {
                garbageItem = garbage.GarbageItem;
            }
            var fullName = garbage.GetName();

            if (maxWeight < garbageItem.Weight || maxSize < garbageItem.M3)
                return null;
            List<object> weightItems = new List<object>();
            List<object> items = new List<object>();

            foreach (var id in garbage.id)
            {
                if (id.ids < 3)
                {

                    WebshopTrashBags bagster = (WebshopTrashBags)webshop.Sections.FirstOrDefault(x => x.ContentType.Alias.Equals("webshopTrashBags"));
                    foreach (TrashBagItem trashBagItem in bagster.TrashBag)
                    {
                        if (trashBagItem.BagId != id.ids)
                            continue;
                        
                        for (int i = 0; i < id.quantity; i++)
                        {
                            items.Add(new trashBagItemJsonDto(trashBagItem));
                        }
                    }
                }
                else if (id.ids == 3)
                {
                    WeightForSale weight = (WeightForSale)webshop.Sections.FirstOrDefault(x => x.ContentType.Alias.Equals("weightForSale"));
                    if (weight.WeightId != id.ids)
                        continue;
                    for (int i = 0; i < id.quantity; i++)
                    {
                        weightItems.Add(new weightJsonDto(weight));
                    }
                }
            }

                var content = _contentService.Create(fullName, int.Parse(garbage.ParentId), "garbageItemM3");
            var weightNested = Newtonsoft.Json.JsonConvert.SerializeObject(weightItems);
            var itemsNested = Newtonsoft.Json.JsonConvert.SerializeObject(items);
            content.SetValue("weightForSale", weightNested);
            content.SetValue("trashBagList", itemsNested);
            content.SetValue("weight", garbageItem.Weight);
            content.SetValue("m3", garbageItem.M3);
            content.SetValue("price", garbageItem.Price);
            content.SetValue("status", "In pick-up queue...");
            _contentService.SaveAndPublish(content);
            return content.Key;
        }
        public FrontpageDto GetFrontpage()
        {
            var frontpage = PageHelper.GetFrontPage();
            var videoUrl = frontpage.BgVideo.Url().ToString();
            WhyOurWayCTADto whyOurWay = new WhyOurWayCTADto();
            HowItWorksCTADto howItWorks = new HowItWorksCTADto();
            ImgTextBtnDTO imgTextBtn = new ImgTextBtnDTO();
            HeaderSubBtnDto header = new HeaderSubBtnDto();
            foreach (var item in frontpage.Sections)
            {
                if (item.ContentType.Alias == "howItWorksCTA")
                    howItWorks = (HowItWorksCTADto)PageHelper.CastToDto(item);
                if (item.ContentType.Alias == "whyOurWayCTA")
                    whyOurWay = (WhyOurWayCTADto)PageHelper.CastToDto(item);
                if (item.ContentType.Alias == "imgTextBtn")
                    imgTextBtn = (ImgTextBtnDTO)PageHelper.CastToDto(item);
                if (item.ContentType.Alias == "headerSubheaderButton")
                    header = (HeaderSubBtnDto)PageHelper.CastToDto(item);
            }
            return new FrontpageDto(howItWorks, whyOurWay, imgTextBtn, header, videoUrl);
        }
        public TrashServicePageDto GetTrashServicePage()
        {
            TrashServicePage trashServicePage = (TrashServicePage)PageHelper.GetPage("trashServicePage");
            SectionsDTO section = new SectionsDTO();
            ButtonCompositionDTO button = new ButtonCompositionDTO();
            foreach (var item in trashServicePage.Sections)
            {
                if (item.ContentType.Alias == "buttonList")
                    button = (ButtonCompositionDTO)PageHelper.CastToDto(item);
                if (item.ContentType.Alias == "section")
                    section = (SectionsDTO)PageHelper.CastToDto(item);
            }
            return new TrashServicePageDto(section, button);
        }
        public ContentPageDTO GetContentPage()
        {
            ContentPage contentPage = (ContentPage)PageHelper.GetPage("contentPage");
            SectionsListDtoContentPage sectionsListDto = new SectionsListDtoContentPage();
            TeamMemberSectionDto teamMemberSectionDto = new TeamMemberSectionDto();
            SectionsDTOContentPage section = new SectionsDTOContentPage();
            HeaderSubBtnDto header = new HeaderSubBtnDto();
            foreach (var item in contentPage.Sections)
            {
                if (item.ContentType.Alias.Equals("sectionListNested", StringComparison.OrdinalIgnoreCase))
                    sectionsListDto = (SectionsListDtoContentPage)PageHelper.CastToSectionPageDTO(item);
                if (item.ContentType.Alias == "teamMemberSection")
                    teamMemberSectionDto = (TeamMemberSectionDto)PageHelper.CastToDto(item);
                if (item.ContentType.Alias == "section")
                    section = (SectionsDTOContentPage)PageHelper.CastToSectionPageDTO(item);
                if (item.ContentType.Alias == "headerSubheaderButton")
                    header = (HeaderSubBtnDto)PageHelper.CastToDto(item);
            }

            return new ContentPageDTO(teamMemberSectionDto, section, sectionsListDto, header);
        }
        public WebshopPageDTO GetWebShopPage()
        {
            WebshopPage webshopPage = (WebshopPage)PageHelper.GetPage("webshopPage");
            ImgTextBtnDTO imgTextBtnDTO = new ImgTextBtnDTO();
            TrashBagSectionDto trashBagSectionDto = new TrashBagSectionDto();
            WeightForSaleDTO weightForSaleDTO = new WeightForSaleDTO();
            foreach (var item in webshopPage.Sections)
            {
                if (item.ContentType.Alias == "webshopTrashBags")
                    trashBagSectionDto = (TrashBagSectionDto)PageHelper.CastToDto(item);
                if (item.ContentType.Alias == "weightForSale")
                    weightForSaleDTO = (WeightForSaleDTO)PageHelper.CastToDto(item);
                if (item.ContentType.Alias == "imgTextBtn")
                    imgTextBtnDTO = (ImgTextBtnDTO)PageHelper.CastToDto(item);
            }

            return new WebshopPageDTO(imgTextBtnDTO, trashBagSectionDto, weightForSaleDTO);
        }
        public NavigationHeaderDto GetNavigationHeader()
        {
            SettingsPage settingsPage = (SettingsPage)PageHelper.GetPage("settingsPage");

            return new NavigationHeaderDto(settingsPage);
        }
        public FooterDto GetFooter()
        {
            SettingsPage settingsPage = (SettingsPage)PageHelper.GetPage("settingsPage");
            return new FooterDto(settingsPage);
        }
        public (List<GarbageItemDTO>, List<GarbageItemM3DTO>) GetOrders()
        {
            List<GarbageItemDTO> orders = new List<GarbageItemDTO>();
            List<GarbageItemM3DTO> ordersM3 = new List<GarbageItemM3DTO>();
            ListOfItems list = (ListOfItems)PageHelper.GetPage("listOfItems");
            var garbageList = list.Children.FirstOrDefault(x => x.ContentType.Alias.Equals("garbageMain", StringComparison.OrdinalIgnoreCase));
            var garbage = garbageList.Children.ToList();
            foreach (var item in garbage)
            {
                if (item.HasProperty("m3"))
                {
                    ordersM3.Add(new GarbageItemM3DTO((GarbageItemM3)item));
                }
                else
                {
                    orders.Add(new GarbageItemDTO((GarbageItem)item));
                }
            }
            return (orders, ordersM3);
        }
        public ReceiptPageDto getReceiptByKey(Guid key)
        {
            var helper = Umbraco.Web.Composing.Current.UmbracoHelper;
            IPublishedContent node = helper.Content(key);
            var content = node;
            ReceiptPage receiptPage = (ReceiptPage)PageHelper.GetPage("receiptPage");
            ReceiptDto receipt = new ReceiptDto(receiptPage);

            if (content.TryConvertTo<GarbageItem>().Success) 
            {
                return new ReceiptPageDto((GarbageItem)content, receiptPage);
            }
            return new ReceiptPageDto((GarbageItemM3)content, receiptPage);
        }

        //ToList().Contains(garbageList.Children.ToList().Find(x => x.Name == orderName)
        public string UpdateStatus(string orderName, string status)
        {

            ListOfItems list = (ListOfItems)PageHelper.GetPage("listOfItems");
            var garbageList = list.Children.FirstOrDefault(x => x.ContentType.Alias.Equals("garbageMain", StringComparison.OrdinalIgnoreCase));
            if (garbageList.Children.Select(x => x.Name == orderName) == null)
                return null;
            var helper = Umbraco.Web.Composing.Current.UmbracoHelper;
            Guid id = garbageList.Children.FirstOrDefault(x => x.Name == orderName).Key;
            var content = _contentService.GetById(id);
            content.SetValue("status", status);
            return status;
        }

        private Dictionary<string, object> SerializeProperties(TrashBagItem trashBagItem, string propertiesToMatch)
        {
            List<string> props = propertiesToMatch.Split(',').ToList();

            Dictionary<string, object> properties = new Dictionary<string, object>();
            foreach (PropertyInfo propertyInfo in trashBagItem.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (!props.Any(a => a.Equals(propertyInfo.Name, StringComparison.OrdinalIgnoreCase)))
                    continue;

                properties.Add(propertyInfo.Name, propertyInfo.GetValue(trashBagItem, null));
            }

            return properties;
        }
        private Dictionary<string, object> SerializeProperties(WeightForSale weight, string propertiesToMatch)
        {
            List<string> props = propertiesToMatch.Split(',').ToList();

            Dictionary<string, object> properties = new Dictionary<string, object>();
            foreach (PropertyInfo propertyInfo in weight.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (!props.Any(a => a.Equals(propertyInfo.Name, StringComparison.OrdinalIgnoreCase)))
                    continue;

                properties.Add(propertyInfo.Name, propertyInfo.GetValue(weight, null));
            }

            return properties;
        }

       
    }
}