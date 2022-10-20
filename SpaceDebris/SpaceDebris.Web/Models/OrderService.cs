//using SpaceDebris.Web.Models.DTOs;
//using SpaceDebris.Web.Models.ModelsBuilder;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Web;
//using Umbraco.Core.Models.PublishedContent;

//namespace SpaceDebris.Web.Models
//{
//    //public int Quantity { get; set; }
//    //public string ItemName { get; set; }
//    //public decimal Price { get; set; }
    
//    public class OrderService
//    {
//        private readonly IPublishedContent _publishedContent;
//        public T CreateDto<T>(object obj, GarbageItem garbage) where T : class
//        {
//            Type type = typeof(T).GetType();
//            PropertyInfo[] myPropertyInfo;
//            myPropertyInfo = type.GetProperties();
//            PropertyInfo[] objProps = obj.GetType().GetProperties();

//            if (garbage.TrashBagList != null)
//            {
//                foreach (var item in garbage.TrashBagList)
//                {
//                    int i = 0;
//                    int j = 0;
//                    objProps.SetValue(i++, 0);
//                    objProps.SetValue(j += item.Price, 1);
//                    //string size = item.Size.ToLower();
//                    //switch (size)
//                    //{
//                    //    case "medium":
//                    //        myPropertyInfo.SetValue(i++, 0);
//                    //        myPropertyInfo.SetValue(j += item.Price, 1);
//                    //        return (T)Convert.ChangeType(obj, type);
//                    //    case "small":
//                    //        myPropertyInfo.SetValue(i++, 0);
//                    //        myPropertyInfo.SetValue(j += item.Price, 1);
//                    //        return (T)Convert.ChangeType(obj, type);
//                    //    case "large":
//                    //        myPropertyInfo.SetValue(i++, 0);
//                    //        myPropertyInfo.SetValue(j += item.Price, 1);
//                    //        return (T)Convert.ChangeType(obj, type);
//                    //    default: break;
//                    //}
//                }
//            }
            
//            return (T)Convert.ChangeType(obj, type);
//        }
//        public TrashBagOrderDto hehe(Guid key) 
//        {
//            var helper = Umbraco.Web.Composing.Current.UmbracoHelper;
//            IPublishedContent node = helper.Content(key);
//            var content = node;
//            TrashBagOrderDto trash = new TrashBagOrderDto();
//            TrashBagOrderDto newDto = CreateDto<TrashBagOrderDto>(trash, (GarbageItem)content);
//            return newDto;
//        }
//    }
//}