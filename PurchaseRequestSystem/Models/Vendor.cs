using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace PurchaseRequestSystem.Models
{
    public class Vendor
    {
        public int ID { get; set; }
        [MaxLength(10)]
        [Index(IsUnique = true)]
        public string Code { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(255)]
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        [MaxLength(5)]
        public string Zip { get; set; }
        [MaxLength(12)]
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public bool IsPreApproved { get; set; } = false;
        public bool Active { get; set; } = true;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        //Requires to be set by database
        //public DateTime DateUpdated { get; set; }
        
    }
}