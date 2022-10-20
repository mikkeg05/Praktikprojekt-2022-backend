using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class UpdateStatusRequestModel
    {
        public string Ordername { get; set; }
        public string Status { get; set; }

        public UpdateStatusRequestModel(string ordername, string status)
        {
            Ordername = ordername;
            Status = status;
        }
    }
}