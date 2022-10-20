using SpaceDebris.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class GarbageFormRequest : IBaseDtoModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public int ParentId { get; set; }
        public string ParentId { get; set; }
        public List<QuantityId> id { get; set; }

       // public List<int> Id { get; set; }

        public GarbageItemDTO GarbageItem { get; set; }

        public string GetName()
        {
            return FirstName + " " + LastName + " " + DateTime.Now.ToString("dd MMM yyyy");
        }
        public bool IsValid()
        {
            return GarbageItem.IsValid() && int.TryParse(ParentId, out int pId);
        }

    }
    public class GarbageM3Request
    {
        public List<QuantityId> id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentId { get; set; }
        public GarbageItemM3DTO GarbageItem { get; set; }
        public string GetName()
        {
            return FirstName + " " + LastName + " " + DateTime.Now.ToString("dd, MMM, yyyy");
        }
        public bool IsValid()
        {
            return GarbageItem.IsValid() && int.TryParse(ParentId, out int pId);
        }
    }
    public class QuantityId
    {
        public int ids { get; set; }
        public int quantity {get; set;}
    }
    
}