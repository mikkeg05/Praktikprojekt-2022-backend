using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class ReceiptPageRequestModel
    {
        public Guid Id { get; set; }

        public ReceiptPageRequestModel(Guid id)
        {
            Id = id;
        }
    }
}