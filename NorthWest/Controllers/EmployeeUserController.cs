using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using NorthWest.DAL;
using NorthWest.Models;
using System.Data.Entity;

namespace NorthWest.Controllers
{
    public class EmployeeUserController : Controller
    {
        private NorthWestContext db = new NorthWestContext();
        public static List<OrderStatus> listOrderStatus = new List<OrderStatus>();
        // GET: EmployeeUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectOrderID()
        {
            return View();
        }
        public ActionResult TrackOrderGetOrderID(int orderID)
        {
            //get customer's order id from customer
            return RedirectToAction("TrackOrder", new { orderID = orderID});

        }




        public ActionResult TrackOrder(int orderID)
        {
            //customer's track your order
            ViewBag.OrderID = orderID;
            ViewBag.Message = "Your order is being tracked.";
            //ViewBag.Output = orderStatus;

            return View(listOrderStatus);
        }

        public ActionResult UpdateOrderStatus()
        {
            //employee updating a customer's order
            //ViewBag.Output = orderStatus;

            return View();
        }

        [HttpPost]
        public ActionResult UpdateOrderStatus(OrderStatus orderStatus)
        {
            //check validity of model
            if (ModelState.IsValid)
            {
                listOrderStatus.Add(orderStatus);
                //return View("Confirmation", customer);
                return View("Index");
            }
            else
            {
                return View();
            }

        }
    }
}