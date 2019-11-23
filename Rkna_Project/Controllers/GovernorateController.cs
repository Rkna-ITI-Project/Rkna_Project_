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
    public class GovernorateController : Controller
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();

        [Authorize(Roles = "admin,manger")]
        // GET: Governorate_Table
        public ActionResult Index()
        {
            return View(db.Governorate_Table.ToList());
        }

        // GET: Governorate_Table/Details/5
        [Authorize(Roles = "admin,manger")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Governorate_Table governorate_Table = db.Governorate_Table.Find(id);
            if (governorate_Table == null)
            {
                return HttpNotFound();
            }
            return View(governorate_Table);
        }

        // GET: Governorate_Table/Create
        [Authorize(Roles = "admin,manger")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Governorate_Table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin,manger")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Gov_ID,Gov_Name,Gov_Desc,Gov_X_Point,Gov_Y_Point")] Governorate_Table governorate_Table)
        {
            if (ModelState.IsValid)
            {
               
                    db.Governorate_Table.Add(governorate_Table);
                    db.SaveChanges();
                
                return RedirectToAction("Index");
            }

            return View(governorate_Table);
        }

        // GET: Governorate_Table/Edit/5
        [Authorize(Roles = "admin,manger")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Governorate_Table governorate_Table = db.Governorate_Table.Find(id);
            if (governorate_Table == null)
            {
                return HttpNotFound();
            }
            return View(governorate_Table);
        }

        // POST: Governorate_Table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin,manger")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Gov_ID,Gov_Name,Gov_Desc,Gov_X_Point,Gov_Y_Point")] Governorate_Table governorate_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(governorate_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(governorate_Table);
        }

        // GET: Governorate_Table/Delete/5
        [Authorize(Roles = "admin,manger")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Governorate_Table governorate_Table = db.Governorate_Table.Find(id);
            if (governorate_Table == null)
            {
                return HttpNotFound();
            }
            return View(governorate_Table);
        }

        // POST: Governorate_Table/Delete/5
        [Authorize(Roles = "admin,manger")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Governorate_Table governorate_Table = db.Governorate_Table.Find(id);
            db.Governorate_Table.Remove(governorate_Table);
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
