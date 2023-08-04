using KitKart.Models;
using System.Data.Entity;

namespace KitKart.Context
{
    public class KartContext : DbContext
    {
        // If We need to use the different nam for DbContext we can go for this contructor
        //public KartContext() : base("MyConnection")
        //{
            
        //}
        public DbSet<KartItems> kartItems { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Role> roles { get; set; }

        public DbSet<Users> users { get; set; }
    }
}
