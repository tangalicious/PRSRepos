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
    public class PRLI
    {
        public int ID { get; set; }
        public int PurchaseRequestID { get; set; }
        public int ProductID { get; set; }
        [Min(0)]
        public int Quantity { get; set; }
        public bool Active { get; set; } = true;
        public DateTime DateCreated { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; }
	    
        //public virtual ICollection<PurchaseRequest> PurchaseRequest { get; set; }
        [JsonIgnore]
        public virtual PurchaseRequest PurchaseRequest { get; set; }
        public virtual Product Product { get; set; }
    }
}