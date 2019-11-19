﻿using System;
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
    public class States_TableController : Controller
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();

        // GET: States_Table
        public ActionResult Index()
        {
            var states_Table = db.States_Table.Include(s => s.Governorate_Table);
            return View(states_Table.ToList());
        }

        // GET: States_Table/Details/5
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
        public ActionResult Create()
        {
            ViewBag.Gov_ID = new SelectList(db.Governorate_Table, "Gov_ID", "Gov_Name");
            return View();
        }

        // POST: States_Table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

            ViewBag.Gov_ID = new SelectList(db.Governorate_Table, "Gov_ID", "Gov_Name", states_Table.Gov_ID);
            return View(states_Table);
        }

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
            ViewBag.Gov_ID = new SelectList(db.Governorate_Table, "Gov_ID", "Gov_Name", states_Table.Gov_ID);
            return View(states_Table);
        }

        // POST: States_Table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewBag.Gov_ID = new SelectList(db.Governorate_Table, "Gov_ID", "Gov_Name", states_Table.Gov_ID);
            return View(states_Table);
        }

        // GET: States_Table/Delete/5
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
