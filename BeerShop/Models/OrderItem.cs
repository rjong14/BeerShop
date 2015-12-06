using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeerShop.Models {
    public class OrderItem {

        public int ID { get; set; }
        [ForeignKey("Beer_ID")]
        public Beer Beer { get; set; }
        public int Beer_ID { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
    }
}