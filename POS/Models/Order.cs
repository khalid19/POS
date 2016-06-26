using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.Expressions;

namespace POS.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int ItemId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

       

        public decimal Unitprice { get; set; }

        public decimal Quantity { get; set; }

        public  virtual decimal TotalPrice { get; set;  }

        public virtual Item Item { set; get; }



        public virtual Customer Customer { get; set; }

        //public decimal TotalPrice
        //{
        //    get { return totalPrice; }
        //    set { totalPrice = value; }
        //}

        //private decimal totalPrice;
    }
}