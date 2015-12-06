using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeerShop.Models {
    public class Type {
        public int ID { get; set; }
        public String Name { get; set; }
        public ICollection<Beer> Beers { get; set; }
    }
}