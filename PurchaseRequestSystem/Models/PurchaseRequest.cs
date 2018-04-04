using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PurchaseRequestSystem.Models
{
    public enum StatusID
    {
        New, Review, Approved, Rejected
    }
    public class PurchaseRequest
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        [MaxLength(100)]
        [Required]
        public string Description { get; set; }
        [Required]
        [MaxLength(255)]
        public string Justification { get; set; }
        //public DateTime DateNeeded { get; set; }
       
        [MaxLength(25)]
        public string DeliveryMode { get; set; }
        
        //Needs to be set to default "New" out of ("New"//"Review"//"Approved"//"Rejected")
        public string Status { get; set; } = "New";
        //Task [MaxLength(20)]
        //Needs to be Calculated by system
        public decimal Total { get; set; } = 0;
        //public DateTime SubmittedDate { get; set; }
        public bool Active { get; set; } = true;
        [MaxLength(100)]
        public string ReasonForRejection { get; set; }
        public DateTime DateCreated { get; set; }
        //public DateTime DateUpdated { get; set; }

        public virtual User User { get; set; }
        //public virtual Status Status { get; set; }
        //public ICollection<PRLI> PRLI { get; set; }
        //public virtual PRLI PRLI { get; set; }
        public virtual List<PRLI> PRLIs { get; set; }
    }
}