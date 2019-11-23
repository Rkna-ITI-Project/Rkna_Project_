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
    public class CustomerController : Controller
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();

        // GET: Customer_Slut_Table
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult Index()
        {
            var customer_Slut_Table = db.Customer_Slut_Table.Include(c => c.AspNetUser).Include(c => c.Car_Specifications_Table).Include(c => c.Slut_Table);
            return View(customer_Slut_Table.ToList());
        }

        // GET: Customer_Slut_Table/Details/5
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Slut_Table customer_Slut_Table = db.Customer_Slut_Table.Find(id);
            if (customer_Slut_Table == null)
            {
                return HttpNotFound();
            }
            return View(customer_Slut_Table);
        }

        // GET: Customer_Slut_Table/Create
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Car_Spe_ID = new SelectList(db.Car_Specifications_Table, "Car_Spe_ID", "Car_Owner_ID");
            ViewBag.Slut_ID = new SelectList(db.Slut_Table, "Slut_ID", "Name");
            return View();
        }

        // POST: Customer_Slut_Table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult Create([Bind(Include = "Customer_Slut_ID,Customer_ID,Slut_ID,Car_Spe_ID,Cus_Slut_Date,Cus_Slut_S_Time,Cus_Slut_E_Time,Cheeck_Code")] Customer_Slut_Table customer_Slut_Table)
        {
            if (ModelState.IsValid)
            {
                db.Customer_Slut_Table.Add(customer_Slut_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.AspNetUsers, "Id", "Email", customer_Slut_Table.Customer_ID);
            ViewBag.Car_Spe_ID = new SelectList(db.Car_Specifications_Table, "Car_Spe_ID", "Car_Owner_ID", customer_Slut_Table.Car_Spe_ID);
            ViewBag.Slut_ID = new SelectList(db.Slut_Table, "Slut_ID", "Name", customer_Slut_Table.Slut_ID);
            return View(customer_Slut_Table);
        }

        // GET: Customer_Slut_Table/Edit/5
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Slut_Table customer_Slut_Table = db.Customer_Slut_Table.Find(id);
            if (customer_Slut_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.AspNetUsers, "Id", "Email", customer_Slut_Table.Customer_ID);
            ViewBag.Car_Spe_ID = new SelectList(db.Car_Specifications_Table, "Car_Spe_ID", "Car_Owner_ID", customer_Slut_Table.Car_Spe_ID);
            ViewBag.Slut_ID = new SelectList(db.Slut_Table, "Slut_ID", "Name", customer_Slut_Table.Slut_ID);
            return View(customer_Slut_Table);
        }

        // POST: Customer_Slut_Table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult Edit([Bind(Include = "Customer_Slut_ID,Customer_ID,Slut_ID,Car_Spe_ID,Cus_Slut_Date,Cus_Slut_S_Time,Cus_Slut_E_Time,Cheeck_Code")] Customer_Slut_Table customer_Slut_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_Slut_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.AspNetUsers, "Id", "Email", customer_Slut_Table.Customer_ID);
            ViewBag.Car_Spe_ID = new SelectList(db.Car_Specifications_Table, "Car_Spe_ID", "Car_Owner_ID", customer_Slut_Table.Car_Spe_ID);
            ViewBag.Slut_ID = new SelectList(db.Slut_Table, "Slut_ID", "Name", customer_Slut_Table.Slut_ID);
            return View(customer_Slut_Table);
        }

        // GET: Customer_Slut_Table/Delete/5
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Slut_Table customer_Slut_Table = db.Customer_Slut_Table.Find(id);
            if (customer_Slut_Table == null)
            {
                return HttpNotFound();
            }
            return View(customer_Slut_Table);
        }

        // POST: Customer_Slut_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer_Slut_Table customer_Slut_Table = db.Customer_Slut_Table.Find(id);
            db.Customer_Slut_Table.Remove(customer_Slut_Table);
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
