using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SuperCarStore.Data
{
    public class SuperCarStoreContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SuperCarStoreContext() : base("name=SuperCarStoreContext")
        {
        }

        public DbSet<SuperCarStore.Models.Car> Cars { get; set; }
        public DbSet<SuperCarStore.Models.Customer> Customers { get; set; }
        public DbSet<SuperCarStore.Models.Store> Stores { get; set; }
        public DbSet<SuperCarStore.Models.MembershipType> MerbershipTypes { get; set; }
    }
}
