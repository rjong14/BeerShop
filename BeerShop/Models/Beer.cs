using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeerShop.Models {
    public class Beer {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Country { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }

    }
    public class BeerDBContext : DbContext {
        public DbSet<Beer> Beers { get; set; }
    }
}