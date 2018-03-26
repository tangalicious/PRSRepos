using DataAnnotationsExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Threading.Tasks;


namespace PurchaseRequestSystem.Models
{
    public class Product
    {
        public int ID { get; set; }
        public int VendorID { get; set; }
        [MaxLength(50)]
        public string PartNumber { get; set; }//Vendor-provided part #
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        //Task decimal [MaxLength(20)]
        [Min(0)] //"Install-Package DataAnnotationsExtensions -Version 5.0.1.27"
        public decimal Price { get; set; }//Can't be negative
        [Required]
        [MaxLength(150)]
        public string Unit { get; set; }
        [MaxLength(255)]
        public string PhotoPath { get; set; }
        public bool Active { get; set; } = true;
        public DateTime DateCreated { get; set; }
        //public DateTime DateUpdated { get; set; }
        

        [JsonIgnore]
        public virtual Vendor Vendor { get; set; }
    }
}