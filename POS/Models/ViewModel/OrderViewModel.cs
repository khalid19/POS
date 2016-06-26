using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Models.ViewModel
{
    public class OrderViewModel:Order
    {
        public override decimal TotalPrice { get { return (Unitprice*Quantity); } }

        public List<Customer> Customers { get; set; }
        public List<Item> Items { get; set; }

        public List<Order> Orders { get; set; }
        public OrderViewModel()
        {
            Customers=new List<Customer>();

            Items=new List<Item>();

            Orders=new List<Order>();
        }


        public virtual IEnumerable<SelectListItem> CustomerSelectListItems
        {
            get { return new SelectList(Customers, "CustomerId", "Name"); }
        }
        public virtual IEnumerable<SelectListItem> ItemSelectListItems
        {
            get { return new SelectList(Items, "ItemId", "ItemName"); }
        }

       
    }
}