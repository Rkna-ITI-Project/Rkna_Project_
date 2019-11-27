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
    public class StatesController : Controller
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();

        // GET: States_Table 
        [Authorize(Roles = "admin,manger")]
        public ActionResult Index()
        {
            var states_Table = db.States_Table.Include(s => s.Governorate_Table);
            return View(states_Table.ToList());
        }

        // GET: States_Table/Details/5
        [Authorize(Roles = "admin,manger")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            States_Table states_Table = db.States_Table.Find(id);
            if (states_Table == null)
            {
                return HttpNotFound();
            }
            return View(states_Table);
        }

        // GET: States_Table/Create
        [Authorize(Roles = "admin,manger")]
        public ActionResult Create()
        {
            ViewBag.Governorate_Table = db.Governorate_Table.ToList();
            return View();
        }

        // POST: States_Table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin,manger")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "States_ID,Gov_ID,States_Name,States_Desc,States_X_Point,States_Y_Point")] States_Table states_Table)
        {

            if (ModelState.IsValid)
            {
                db.States_Table.Add(states_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Governorate_Table = db.Governorate_Table.ToList();
            return View(states_Table);
        }
         
        [Authorize(Roles = "admin,manger")]
        // GET: States_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            States_Table states_Table = db.States_Table.Find(id);
            if (states_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.Governorate_Table = db.Governorate_Table.ToList();

            return View(states_Table);
        }

        // POST: States_Table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin,manger")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "States_ID,Gov_ID,States_Name,States_Desc,States_X_Point,States_Y_Point")] States_Table states_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(states_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Governorate_Table = db.Governorate_Table.ToList();
            return View(states_Table);
        }

        // GET: States_Table/Delete/5
        [Authorize(Roles = "admin,manger")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            States_Table states_Table = db.States_Table.Find(id);
            if (states_Table == null)
            {
                return HttpNotFound();
            }
            return View(states_Table);
        }

        // POST: States_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin,manger")]
        public ActionResult DeleteConfirmed(int id)
        {
            States_Table states_Table = db.States_Table.Find(id);
            db.States_Table.Remove(states_Table);
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
