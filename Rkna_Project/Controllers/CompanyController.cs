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
    public class CompanyController : Controller
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();

        // GET: Company_Table
        [Authorize(Roles = "admin,manger")]
        public ActionResult Index()
        {
            return View(db.Company_Table.ToList());
        }

        // GET: Company_Table/Details/5
        [Authorize(Roles = "admin,manger")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Table company_Table = db.Company_Table.Find(id);
            if (company_Table == null)
            {
                return HttpNotFound();
            }
            return View(company_Table);
        }

        // GET: Company_Table/Create
        [Authorize(Roles = "admin,manger")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company_Table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin,manger")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Company_Info_ID,Company_Name,Company_Desc,Com_Pnone1,Com_Pnone2,Com_Pnone3,Comp_Manger")] Company_Table company_Table)
        {
            if (ModelState.IsValid)
            {
                if (db.Company_Table.ToList().Count == 0)
                {
                    db.Company_Table.Add(company_Table);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(company_Table);
        }

        // GET: Company_Table/Edit/5
        [Authorize(Roles = "admin,manger")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Table company_Table = db.Company_Table.Find(id);
            if (company_Table == null)
            {
                return HttpNotFound();
            }
            return View(company_Table);
        }

        // POST: Company_Table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin,manger")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Company_Info_ID,Company_Name,Company_Desc,Com_Pnone1,Com_Pnone2,Com_Pnone3,Comp_Manger")] Company_Table company_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company_Table);
        }

        // GET: Company_Table/Delete/5
        [Authorize(Roles = "admin,manger")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Table company_Table = db.Company_Table.Find(id);
            if (company_Table == null)
            {
                return HttpNotFound();
            }
            return View(company_Table);
        }

        // POST: Company_Table/Delete/5
        [Authorize(Roles = "admin,manger")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company_Table company_Table = db.Company_Table.Find(id);
            db.Company_Table.Remove(company_Table);
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
