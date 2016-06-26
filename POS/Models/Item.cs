using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        [DisplayName("Item Name")]
        public string ItemName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}