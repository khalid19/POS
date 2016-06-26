using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POS.Models;
using POS.Models.ViewModel;
using PagedList;

namespace POS.Controllers
{
    public class OrderController : Controller
    {
        private POSDbContext db = new POSDbContext();

        // GET: /Order/
        public ActionResult Index(OrderViewModel model, int? page)
        {
            model.Customers = db.Customers.ToList();
            model.Items = db.Items.ToList();
            var orders = db.Orders.Include(x => x.Customer).Include(x => x.Item).Where(x => x.CustomerId == model.CustomerId || model.CustomerId == 0).ToList();
            model.Orders = orders;
            if (model.ItemId > 0)
            {
                model.Orders = orders.Where(x => x.ItemId == model.ItemId).ToList();
            }
            //int pageSize = 3;
            // int pageNumber = (page ?? 1);
            // return View(model.Orders.ToPagedList(pageSize,pageNumber));
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(OrderViewModel model)
        {
            var anOrder = db.Orders.Find(model.OrderId) ?? new Order();
            model.OrderId = anOrder.OrderId;
            model.CustomerId = anOrder.CustomerId;
            model.ItemId = anOrder.ItemId;
            model.Date = anOrder.Date;
            model.Quantity = anOrder.Quantity;
            model.Unitprice = anOrder.Unitprice;
            model.TotalPrice = anOrder.TotalPrice;


            model.Customers = db.Customers.ToList();
            model.Items = db.Items.ToList();

            return View("Edit", model);
        }
        [HttpPost]
        public ActionResult Save(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {


                Order anOrder = new Order();
                anOrder.OrderId = model.OrderId;
                anOrder.CustomerId = model.CustomerId;
                anOrder.ItemId = model.ItemId;
                anOrder.Date = model.Date;
                anOrder.Quantity = model.Quantity;
                anOrder.Unitprice = model.Unitprice;
                anOrder.TotalPrice = model.TotalPrice;

                if (model.OrderId > 0)
                {
                    db.Entry(anOrder).State = EntityState.Modified;
                }
                else
                {
                    db.Orders.Add(anOrder);
                }
                int saveChanges = db.SaveChanges();

                if (saveChanges > 0)
                {
                    return RedirectToAction("Index", model);
                }
            }
            model.Customers = db.Customers.ToList();
            model.Items = db.Items.ToList();

            return View("Edit", model);
        }

        public ActionResult Delete(OrderViewModel model)
        {
            Order orderObj = db.Orders.Find(model.OrderId);

            if (model.OrderId > 0)
            {
                db.Entry(orderObj).State = EntityState.Deleted;
            }

            int saveChanges = db.SaveChanges();

            if (saveChanges > 0)
            {
                return RedirectToAction("Index", model);
            }
            return View("Error");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
