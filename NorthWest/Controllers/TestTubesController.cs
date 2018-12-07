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
    public class TestTubesController : Controller
    {
        private NorthWestContext db = new NorthWestContext();

        // GET: TestTubes
        public ActionResult Index()
        {
            var testTubes = db.TestTubes.Include(t => t.Sample).Include(t => t.Test);
            return View(testTubes.ToList());
        }

        // GET: TestTubes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestTube testTube = db.TestTubes.Find(id);
            if (testTube == null)
            {
                return HttpNotFound();
            }
            return View(testTube);
        }

        // GET: TestTubes/Create
        public ActionResult Create()
        {
            ViewBag.SampleID = new SelectList(db.Samples, "SampleID", "SampleName");
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "TestName");
            return View();
        }

        // POST: TestTubes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestTubeID,SampleID,TestTubeNo,TechID,TestID,TotalMaterialCost,QuantResult,QualResult,Pass_Fail,TotalCost")] TestTube testTube)
        {
            if (ModelState.IsValid)
            {
                db.TestTubes.Add(testTube);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SampleID = new SelectList(db.Samples, "SampleID", "SampleName", testTube.SampleID);
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "TestName", testTube.TestID);
            return View(testTube);
        }

        // GET: TestTubes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestTube testTube = db.TestTubes.Find(id);
            if (testTube == null)
            {
                return HttpNotFound();
            }
            ViewBag.SampleID = new SelectList(db.Samples, "SampleID", "SampleName", testTube.SampleID);
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "TestName", testTube.TestID);
            return View(testTube);
        }

        // POST: TestTubes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestTubeID,SampleID,TestTubeNo,TechID,TestID,TotalMaterialCost,QuantResult,QualResult,Pass_Fail,TotalCost")] TestTube testTube)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testTube).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SampleID = new SelectList(db.Samples, "SampleID", "SampleName", testTube.SampleID);
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "TestName", testTube.TestID);
            return View(testTube);
        }

        // GET: TestTubes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestTube testTube = db.TestTubes.Find(id);
            if (testTube == null)
            {
                return HttpNotFound();
            }
            return View(testTube);
        }

        // POST: TestTubes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestTube testTube = db.TestTubes.Find(id);
            db.TestTubes.Remove(testTube);
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
