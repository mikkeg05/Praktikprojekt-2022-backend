﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class JsonDtoBase
    {
        [JsonProperty("ncContentTypeAlias")]
        public string Alias { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}