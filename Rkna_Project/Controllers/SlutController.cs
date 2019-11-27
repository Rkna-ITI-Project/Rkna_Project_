using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rkna_Project.Models;

namespace Rkna_Project.Controllers
{
    public class SlutController : Controller
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities(); 

        [Authorize(Roles = "admin,manger")]
        // GET: Slut_Table
        public ActionResult Index()
        {
            var slut_Table = db.Slut_Table.Include(s => s.Area_Table);
            return View(slut_Table.ToList());
        }

        // GET: Slut_Table/Details/5
        [Authorize(Roles = "admin,manger")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slut_Table slut_Table = db.Slut_Table.Find(id);
            if (slut_Table == null)
            {
                return HttpNotFound();
            }
            return View(slut_Table);
        }

        // GET: Slut_Table/Create
        [Authorize(Roles = "admin,manger")]
        public ActionResult Create()
        {
            ViewBag.Governorate_Table = db.Governorate_Table.ToList();
            ViewBag.Area_Table = db.Area_Table.ToList();
            return View();
        }

        // POST: Slut_Table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin,manger")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Slut_ID,Area_ID,Name,Slut_Level,Slut_X_Point,Slut_Y_Point,Slut_State")] Slut_Table slut_Table)
        {
            if (ModelState.IsValid)
            {
                db.Slut_Table.Add(slut_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Governorate_Table = db.Governorate_Table.ToList();
            ViewBag.Area_Table = db.Area_Table.ToList(); return View(slut_Table);
        }

        // GET: Slut_Table/Edit/5
        [Authorize(Roles = "admin,manger")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slut_Table slut_Table = db.Slut_Table.Find(id);
            if (slut_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.Governorate_Table = db.Governorate_Table.ToList();
            ViewBag.Area_Table = db.Area_Table.ToList();
            return View(slut_Table);
        }

        // POST: Slut_Table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin,manger")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Slut_ID,Area_ID,Name,Slut_Level,Slut_X_Point,Slut_Y_Point,Slut_State")] Slut_Table slut_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slut_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
      ViewBag.Governorate_Table = db.Governorate_Table.ToList();
            ViewBag.Area_Table = db.Area_Table.ToList();
            return View(slut_Table);
        }

        // GET: Slut_Table/Delete/5
        [Authorize(Roles = "admin,manger")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slut_Table slut_Table = db.Slut_Table.Find(id);
            if (slut_Table == null)
            {
                return HttpNotFound();
            }
            return View(slut_Table);
        }

        // POST: Slut_Table/Delete/5
        [Authorize(Roles = "admin,manger")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slut_Table slut_Table = db.Slut_Table.Find(id);
            db.Slut_Table.Remove(slut_Table);
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
