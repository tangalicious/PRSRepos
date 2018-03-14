using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DataAnnotationsExtensions;
using Newtonsoft.Json;

namespace PurchaseRequestSystem.Models
{
    public class PRLIs
    {
        public int ID { get; set; }
        public int PurchaseRequestID { get; set; }
        public int ProductID { get; set; }
        [Min(0)]
        public int Quantity { get; set; }
        public bool Active { get; set; } = true;
        public DateTime DateCreated { get; set; }
        //public DateTime DateUpdated { get; set; }
        public int UpdatedByUser { get; set; }

       // [JsonIgnore]
        //public virtual ICollection<Product> Products { get; set; }
        [JsonIgnore]
        public virtual PurchaseRequest PurchaseRequest { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}