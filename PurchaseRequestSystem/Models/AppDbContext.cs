using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace PurchaseRequestSystem.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base() { }

        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public DbSet<PRLI> PRLIs { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
    }
}