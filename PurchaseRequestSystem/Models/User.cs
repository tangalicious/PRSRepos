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
    public class User
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(75)]
        public string Email { get; set; }
        public bool IsReviewer { get; set; }
        public bool IsAdmin { get; set; }
        public bool Active { get; set; } = true;
        //DateCreated requires database entry
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        //public DateTime DateUpdated { get; set; }
        public int UpdatedByUser { get; set; }

    }
}