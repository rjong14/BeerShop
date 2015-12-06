using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeerShop.Models {
    public enum State {
        Confirmed,
        Delivery,
        Complete
    }
    public class Order {

        public int ID { get; set; }
        public int User_ID;
        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public State State { get; set; }

    }
}