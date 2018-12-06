﻿using System;
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
            //ViewBag.OrderID = new SelectList(db.WorkOrders, OrderID, "OrderID");
            //(db.WorkOrders, "OrderID", "OrderID");
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
    }
}