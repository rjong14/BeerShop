using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeerShop.Models {
    public class Beer {

        public int ID { get; set; }
        public String Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [ForeignKey("Country_ID")]
        public virtual Country Country { get; set; }
        public int? Country_ID { get; set; }
        public virtual ICollection<Type> Type { get; set; }
        public double Price { get; set; }

    }
}