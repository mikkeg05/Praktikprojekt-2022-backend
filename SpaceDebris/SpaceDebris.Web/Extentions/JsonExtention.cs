using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Extentions
{
    public static class JsonExtention
    {
        public static object ToJson(this object obj)
        {
            if (obj == null)
                return null;
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                //StringEscapeHandling = StringEscapeHandling.EscapeHtml,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}