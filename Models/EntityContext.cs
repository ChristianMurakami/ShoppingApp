using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShoppingApp.Models
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options) 
        { }

       public DbSet<User> Users { set; get; }
       public DbSet<Item> Items { set; get; }
       public DbSet<Order> Orders { set; get; } 
       public DbSet<Category> Categories { set; get; }
       public DbSet<ItemNCount> ItemsNCounts { set; get; }
    }
}
