/*
    Team 1-3: Tiara Johnson, Bailey Coleman, HaiJung Hsu, and Ethan Guinn
    Description: Intex
    Date: 12/07/2018
 */
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
        public static int currentCustID = 1;
        public ActionResult Index()
        {
            return RedirectToAction("CustomerLogin");
        }
        //we created the customer login view, but for the demonstration purpose, we decided to prepare a few existing customer
        //accounts for Intex user to choose from
        //soon as we receive approval to move forward with this project, we will be adding customer credentials table for login verification
        public ActionResult CustomerLogin()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustName");
            return View();
        }
        //Right now, we created a dropdown list of customers for intex users to choose from
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerLogin([Bind(Include = "CustomerID")] WorkOrder workOrder)
        {
            currentCustID = workOrder.CustomerID;
            return RedirectToAction("CustomerDashboard");
        }
        //once login, the user will be brought to the user dashboard view with customer's basic information
        public ActionResult CustomerDashboard()
        {
            ViewBag.custName = db.Customers.Find(currentCustID).CustName;
            //currentCustID is the indicator for the user of current login, submitted to the viewbag so it can be used in the view as well
            ViewBag.custID = currentCustID;
            return View();
        }
        //we allow customers to edit their own profile
        public ActionResult EditProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        //after submitting the eidted information, the website will take the user back to the dashboard
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "CustomerID,CustName,Address,Phone,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CustomerDashboard");
            }
            return View(customer);
        }
        //we created a view for customers to see their orders with order detail and a link to the order status if availiable
        public ActionResult CustOrders()
        {
            ViewBag.custID = currentCustID;
            var workOrders = db.WorkOrders.Include(w => w.Customer).Include(w => w.SalesAgent);
            return View(workOrders.ToList());
        }
        //because the order status are input from the employee of the company, we use a different controller for actions of employees
        public ActionResult TrackOrderTransfer(int id)
        {
            return RedirectToAction("TrackOrder", "EmployeeUser", new { orderID = id});
        }
        //we created a form for customer to place an order via our website
        public ActionResult PlaceOrder()
        {
            ViewBag.AgentID = new SelectList(db.SalesAgents, "AgentID", "AgentName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlaceOrder([Bind(Include = "OrderID,AgentID,CustomerID,TestTubeID,PaymentInfo,Comments,DiscountApplied,Deposit")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                workOrder.CustomerID = currentCustID;
                db.WorkOrders.Add(workOrder);
                db.SaveChanges();
                return RedirectToAction("SampleForm", new { OrderID = workOrder.OrderID });
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustName", workOrder.CustomerID);
            ViewBag.AgentID = new SelectList(db.SalesAgents, "AgentID", "AgentName", workOrder.AgentID);
            return View();
        }
        //once order is place, we then show the customer the sample form to fill out, and each order can have as many samples as needed
        public ActionResult SampleForm(int OrderID)
        {
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "AssayName");
            ViewBag.OrderID = OrderID;
            return View();
        }
        //becasue there can be more than one samples, we created a "add new sample" button, as well as "submit" button if all the samples were entered
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
        //after submitting the order and the sample form, the website will take user to a confirmation page with more instructions
        //about what to do next
        public ActionResult Confirmation(int OrderID)
        {
            ViewBag.OrderID = OrderID;
            return View(db.Samples.ToList());
        }
        
        //we created a view for customer to see all the invoice that has been created for their order
        public ActionResult CustInvoice()
        {
            ViewBag.CustID = currentCustID;
            var invoices = db.Invoices.Include(i => i.WorkOrder);
            return View(invoices.ToList());
        }
        //through the list of invoice, the customers can go in and look at the detail of each order that has been completed and invoiced
        public ActionResult OrderAssayList(int id)
        {
            ViewBag.OrderID = id;
            var samples = db.Samples.Include(s => s.Assay).Include(s => s.WorkOrder);
            return View(samples.ToList());
        }
        //test results are the most important thing the customers are looking for
        public ActionResult TestResults(int id, string sampleName)
        {
            ViewBag.SampleID = id;
            ViewBag.SampleName = sampleName;
            var testTubes = db.TestTubes.Include(t => t.Sample).Include(t => t.Test);
            return View(testTubes.ToList());
        }

    }
}