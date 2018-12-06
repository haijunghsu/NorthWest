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
    public class HomeController : Controller
    {
        private NorthWestContext db = new NorthWestContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PlaceOrder()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustName");
            ViewBag.AgentID = new SelectList(db.SalesAgents, "AgentID", "AgentName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlaceOrder([Bind(Include = "OrderID,AgentID,CustomerID,TestTubeID,PaymentInfo,Comments,DiscountApplied,Deposit")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                db.WorkOrders.Add(workOrder);
                db.SaveChanges();
                return RedirectToAction("SampleForm", new { OrderID = workOrder.OrderID });
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustName", workOrder.CustomerID);
            ViewBag.AgentID = new SelectList(db.SalesAgents, "AgentID", "AgentName", workOrder.AgentID);
            return View();
        }

        public ActionResult SampleForm(int OrderID)
        {
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "AssayName");
            ViewBag.OrderID = OrderID;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SampleForm([Bind(Include = "SampleID,AssayID,Quantity,WeightByClient,SampleName")] Sample sample, int OrderID, string answer)
        {
            if (ModelState.IsValid)
            {
                sample.OrderID = OrderID;
                db.Samples.Add(sample);
                db.SaveChanges();

                switch (answer)
                {
                    case "Add New Sample":
                        return RedirectToAction("SampleForm", new { OrderID = OrderID });
                    case "Submit Sample(s)":
                        return RedirectToAction("Confirmation", new { OrderID = OrderID });
                }
            }

            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "AssayName", sample.AssayID);
            ViewBag.OrderID = new SelectList(db.WorkOrders, "OrderID", "PaymentInfo", sample.OrderID);
            return View(sample);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Confirmation(int OrderID)
        {
            ViewBag.OrderID = OrderID;
            return View(db.Samples.ToList());
        }

        public static List<OrderStatus> listOrderStatus = new List<OrderStatus>();

        public ActionResult TrackOrderGetOrderID()
        {
            //get customer's order id from customer
            ViewBag.OrderID = 0;
            return View();

        }

        public ActionResult TrackOrder()
        {
            //customer's track your order
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

        public ActionResult SelectCust()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectCust([Bind(Include = "CustomerID")] WorkOrder workOrder)
        {
            int CustID = workOrder.CustomerID;
            return RedirectToAction("CustInvoice", new { CustID = CustID });
        }

        public ActionResult CustInvoice(int CustID)
        {
            ViewBag.CustID = CustID;
            var invoices = db.Invoices.Include(i => i.WorkOrder);
            return View(invoices.ToList());
        }

        public ActionResult OrderAssayList(int id)
        {
            ViewBag.OrderID = id;
            var samples = db.Samples.Include(s => s.Assay).Include(s => s.WorkOrder);
            return View(samples.ToList());
        }
        
        public ActionResult TestResults(int id, string sampleName)
        {
            ViewBag.SampleID = id;
            ViewBag.SampleName = sampleName;
            var testTubes = db.TestTubes.Include(t => t.Sample).Include(t => t.Test);
            return View(testTubes.ToList());
        }

    }
}