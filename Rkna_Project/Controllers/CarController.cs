using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Rkna_Project.Models;
 
namespace Rkna_Project.Controllers
{
    public class CarController : Controller
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();

        // GET: Car_Specifications_Table
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult Index()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            AspNetUserRole Ob = db.AspNetUserRoles.Where(r => r.UserId == user.Id).FirstOrDefault();


           List< Car_Specifications_Table> car_Specifications_Table=null;
            if (Ob.RoleId == "user")
            {
                car_Specifications_Table = db.Car_Specifications_Table.Where(c => c.Car_Owner_ID== user.Id).ToList();
            }
            else if (Ob.RoleId == "admin" || Ob.RoleId == "manager")
            {
                car_Specifications_Table = db.Car_Specifications_Table.ToList();
            }

            return View(car_Specifications_Table);
        }

        // GET: Car_Specifications_Table/Details/5
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_Specifications_Table car_Specifications_Table = db.Car_Specifications_Table.Find(id);
            if (car_Specifications_Table == null)
            {
                return HttpNotFound();
            }
            return View(car_Specifications_Table);
        }

        // GET: Car_Specifications_Table/Create
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult Create()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            AspNetUserRole Ob = db.AspNetUserRoles.Where(r => r.UserId == user.Id).FirstOrDefault();

            if (Ob.RoleId == "user")
            {
                ViewBag.Car_Owner_ID = db.AspNetUsers.Where(c => c.Id == user.Id).ToList();
            }
            else if (Ob.RoleId == "admin" || Ob.RoleId == "manager")
            {
                ViewBag.Car_Owner_ID = db.AspNetUsers.ToList();
            }
            return View();
        }

        // POST: Car_Specifications_Table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult Create([Bind(Include = "Car_Spe_ID,Car_Owner_ID,Care_Model,Car_plate_Number")] Car_Specifications_Table car_Specifications_Table)
        {
            if (ModelState.IsValid)
            {
                db.Car_Specifications_Table.Add(car_Specifications_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Car_Owner_ID = new SelectList(db.AspNetUsers, "Id", "Email", car_Specifications_Table.Car_Owner_ID);
            return View(car_Specifications_Table);
        }

        // GET: Car_Specifications_Table/Edit/5
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_Specifications_Table car_Specifications_Table = db.Car_Specifications_Table.Find(id);
            if (car_Specifications_Table == null)
            {
                return HttpNotFound();
            }
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            AspNetUserRole Ob = db.AspNetUserRoles.Where(r => r.UserId == user.Id).FirstOrDefault();

            if (Ob.RoleId == "user")
            {
                ViewBag.Car_Owner_ID = db.AspNetUsers.Where(c => c.Id == user.Id).ToList();
            }
            else if (Ob.RoleId == "admin" || Ob.RoleId == "manager")
            {
                ViewBag.Car_Owner_ID = db.AspNetUsers.ToList();
            }
            return View(car_Specifications_Table);
        }

        // POST: Car_Specifications_Table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult Edit([Bind(Include = "Car_Spe_ID,Car_Owner_ID,Care_Model,Car_plate_Number")] Car_Specifications_Table car_Specifications_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car_Specifications_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            AspNetUserRole Ob = db.AspNetUserRoles.Where(r => r.UserId == user.Id).FirstOrDefault();

            if (Ob.RoleId == "user")
            {
                ViewBag.Car_Owner_ID = db.AspNetUsers.Where(c => c.Id == user.Id).ToList();
            }
            else if (Ob.RoleId == "admin" || Ob.RoleId == "manager")
            {
                ViewBag.Car_Owner_ID = db.AspNetUsers.ToList();
            }
            return View(car_Specifications_Table);
        }

        // GET: Car_Specifications_Table/Delete/5
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_Specifications_Table car_Specifications_Table = db.Car_Specifications_Table.Find(id);
            if (car_Specifications_Table == null)
            {
                return HttpNotFound();
            }
            return View(car_Specifications_Table);
        }

        // POST: Car_Specifications_Table/Delete/5
        [Authorize(Roles = "admin,manger")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car_Specifications_Table car_Specifications_Table = db.Car_Specifications_Table.Find(id);
            db.Car_Specifications_Table.Remove(car_Specifications_Table);
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
