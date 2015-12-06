using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeerShop.Models {
    public partial class Beercontext : DbContext {
            public virtual DbSet<Beer> Beers { get; set; }
            public virtual DbSet<Country> Countries { get; set; }
            public virtual DbSet<Order> Orders { get; set; }
            public virtual DbSet<Type> Types { get; set; }
            public virtual DbSet<User> Users { get; set; }
            public virtual DbSet<OrderItem> OrderItem { get; set; }
    }
}