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
    public class CustomerController : Controller
    {
        private Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();

        // GET: Customer_Slut_Table
        [Authorize(Roles = "user,admin,manger")]
        public ActionResult Index()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            AspNetUserRole Ob = db.AspNetUserRoles.Where(r => r.UserId == user.Id).FirstOrDefault();


            List<Customer_Slut_Table> customer_Slut_Table = null;
            if (Ob.RoleId == "user")
            {
                customer_Slut_Table = db.Customer_Slut_Table.Where(c => c.Customer_ID == user.Id).ToList();
            }
            else if (Ob.RoleId == "admin" || Ob.RoleId == "manager")
            {
                customer_Slut_Table = db.Customer_Slut_Table.ToList();
            }


          return  View(customer_Slut_Table);
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
            /// cheeck with email and get customer cars and all data
            /// WE CALLING USER WHO IS REGISTER FORM BEGIN
            
           ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            
            ViewBag.Customer = user.Id;
            ViewBag.Car_Specifications = db.Car_Specifications_Table.Where(c=>c.Car_Owner_ID==user.Id).ToList();
            ViewBag.Slut_ID = db.Slut_Table.ToList();
            ViewBag.Governorate_Table = db.Governorate_Table.ToList();
            return View();
        }

        public ActionResult getArea()
        {
            return Json(db.Area_Table.Select(x => new
            {
                States_ID = x.States_ID,
                Area_Name = x.Area_Name,
                Area_ID = x.Area_ID
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult getSluts()
        {
            return Json(db.Slut_Table.Select(x => new
            {
                Area_ID = x.Area_ID,
                Name = x.Name,
                Slut_ID = x.Slut_ID,
                Slut_Level = x.Slut_Level,
                Slut_State = x.Slut_State
            }).ToList(), JsonRequestBehavior.AllowGet);
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
                Slut_Table Obj = db.Slut_Table.Where(sl => sl.Slut_ID == customer_Slut_Table.Slut_ID).FirstOrDefault();
                Obj.Slut_State = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            ViewBag.Customer = user;
            ViewBag.Car_Specifications = db.Car_Specifications_Table.Where(c => c.Car_Owner_ID == user.Id).ToList();
            ViewBag.Slut_ID = db.Slut_Table.ToList();
            ViewBag.Governorate_Table = db.Governorate_Table.ToList();

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
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            ViewBag.Customer = user.Id;
            ViewBag.Car_Specifications = db.Car_Specifications_Table.Where(c => c.Car_Owner_ID == user.Id).ToList();
            ViewBag.Slut_ID = db.Slut_Table.ToList();
            ViewBag.Governorate_Table = db.Governorate_Table.ToList();
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
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            ViewBag.Customer = user.Id;
            ViewBag.Car_Specifications = db.Car_Specifications_Table.Where(c => c.Car_Owner_ID == user.Id).ToList();
            ViewBag.Slut_ID = db.Slut_Table.ToList();
            ViewBag.Governorate_Table = db.Governorate_Table.ToList();
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
