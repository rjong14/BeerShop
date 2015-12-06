using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeerShop.Models {
    public class User {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string adress { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Boolean IsAdmin { get; set; }
    }
}