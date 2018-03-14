using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace PurchaseRequestSystem.Models
{
    public class Status
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(20)]
        public string Description { get; set; }
        public bool Active { get; set; } = true;
        public DateTime DateCreated { get; set; }
        //public DateTime DateUpdated { get; set; }
        public int UpdatedByUser { get; set; }
    }
}