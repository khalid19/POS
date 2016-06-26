using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Order> Orders { set; get; } 
    }
}