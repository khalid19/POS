using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using POS.Models.ViewModel;

namespace POS.Models
{
    public class POSDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderViewModel> OrderViewModels { get; set; }


    }
}