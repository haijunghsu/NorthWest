using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NorthWest.DAL;
using NorthWest.Models;

namespace NorthWest.Controllers
{
    public class Test_MaterialController : Controller
    {
        private NorthWestContext db = new NorthWestContext();

        // GET: Test_Material
        public ActionResult Index()
        {
            var material_Tests = db.Material_Tests.Include(t => t.Material).Include(t => t.Test);
            return View(material_Tests.ToList());
        }

        // GET: Test_Material/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Material test_Material = db.Material_Tests.Find(id);
            if (test_Material == null)
            {
                return HttpNotFound();
            }
            return View(test_Material);
        }

        // GET: Test_Material/Create
        public ActionResult Create()
        {
            ViewBag.MaterialID = new SelectList(db.Materials, "MaterialID", "MaterialName");
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "TestName");
            return View();
        }

        // POST: Test_Material/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestID,MaterialID")] Test_Material test_Material)
        {
            if (ModelState.IsValid)
            {
                db.Material_Tests.Add(test_Material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaterialID = new SelectList(db.Materials, "MaterialID", "MaterialName", test_Material.MaterialID);
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "TestName", test_Material.TestID);
            return View(test_Material);
        }

        // GET: Test_Material/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Material test_Material = db.Material_Tests.Find(id);
            if (test_Material == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaterialID = new SelectList(db.Materials, "MaterialID", "MaterialName", test_Material.MaterialID);
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "TestName", test_Material.TestID);
            return View(test_Material);
        }

        // POST: Test_Material/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestID,MaterialID")] Test_Material test_Material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test_Material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaterialID = new SelectList(db.Materials, "MaterialID", "MaterialName", test_Material.MaterialID);
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "TestName", test_Material.TestID);
            return View(test_Material);
        }

        // GET: Test_Material/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Material test_Material = db.Material_Tests.Find(id);
            if (test_Material == null)
            {
                return HttpNotFound();
            }
            return View(test_Material);
        }

        // POST: Test_Material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test_Material test_Material = db.Material_Tests.Find(id);
            db.Material_Tests.Remove(test_Material);
            db.SaveChanges();
            return RedirectToAction("Index");
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
