using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class DexContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        // --------------------------------------------------------

        public DbSet<User> Users { get; set; }
        public DbSet<Authority> Authorities { get; set; }
        public DbSet<UserAuthority> UserAuthorities { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<RestaurantMenu> RestaurantMenus { get; set; }

    }
}
