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
    public class AreaController : Controller
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();

        // GET: Area_Table

        [Authorize(Roles = "admin,manger")]
        public ActionResult Index()
        {
            var area_Table = db.Area_Table.Include(a => a.AspNetUser).Include(a => a.AspNetUser1).Include(a => a.States_Table);
            return View(area_Table.ToList());
        }

        // GET: Area_Table/Details/5
        [Authorize(Roles = "admin,manger")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area_Table area_Table = db.Area_Table.Find(id);
            if (area_Table == null)
            {
                return HttpNotFound();
            }
            return View(area_Table);
        }

        // GET: Area_Table/Create
        [Authorize(Roles = "admin,manger")]
        public ActionResult Create()
        {   
            ViewBag.Area_Manger = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Governorate_Table = db.Governorate_Table.ToList();
            ViewBag.State = db.States_Table.ToList();
            return View();
        }
        public ActionResult getCity()
        {
            return Json(db.States_Table.Select(x => new
            {
                States_ID = x.States_ID,
                States_Name = x.States_Name,
                Gov_ID = x.Gov_ID
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
        // POST: Area_Table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin,manger")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Area_ID,States_ID,Area_Name,Area_Desc,Area_X_Point,Area_Y_Point,Area_Manger,Area_Hour_Rate,Area_Start_Time,Area_End_Time")] Area_Table area_Table)
        {
            if (ModelState.IsValid)
            {
                db.Area_Table.Add(area_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Area_Manger = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Governorate_Table = db.Governorate_Table.ToList();
            ViewBag.State = db.States_Table.ToList();
            return View(area_Table);
        }

        // GET: Area_Table/Edit/5
        [Authorize(Roles = "admin,manger")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area_Table area_Table = db.Area_Table.Find(id);
            if (area_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.Area_Manger = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Governorate_Table = db.Governorate_Table.ToList();
            ViewBag.State = db.States_Table.ToList();
            return View(area_Table);
        }

        // POST: Area_Table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin,manger")]
        public ActionResult Edit([Bind(Include = "Area_ID,States_ID,Area_Name,Area_Desc,Area_X_Point,Area_Y_Point,Area_Manger,Area_Hour_Rate,Area_Start_Time,Area_End_Time")] Area_Table area_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(area_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Area_Manger = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Governorate_Table = db.Governorate_Table.ToList();
            ViewBag.State = db.States_Table.ToList();
            return View(area_Table);
        }

        // GET: Area_Table/Delete/5
        [Authorize(Roles = "admin,manger")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area_Table area_Table = db.Area_Table.Find(id);
            if (area_Table == null)
            {
                return HttpNotFound();
            }
            return View(area_Table);
        }

        // POST: Area_Table/Delete/5
        [Authorize(Roles = "admin,manger")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Area_Table area_Table = db.Area_Table.Find(id);
            db.Area_Table.Remove(area_Table);
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
