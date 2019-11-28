using Rkna_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Rkna_Project.Controllers
{
    public class Manag_AccountController : Controller 
    {
        Rkna_DataBaseEntities db = new Rkna_DataBaseEntities();
        // GET: Manag_Account
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.AspNetUserRoles.ToList());

        }

        [Authorize(Roles = "admin")]
        public ActionResult changeRule(AspNetUser User )
        {

            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserRole UserRole = db.AspNetUserRoles.Where(ur=>ur.UserId==id).FirstOrDefault();
            if (UserRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.Area_ID =db.AspNetUsers.Where(use=>use.Id==id).FirstOrDefault();
            return View(UserRole);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit( AspNetUserRole AspNetUserRole)
        {
            AspNetUserRole Obj = db.AspNetUserRoles.Where(r=>r.UserId==AspNetUserRole.UserId).FirstOrDefault();

            if (ModelState.IsValid)
            {
                Obj = AspNetUserRole;

                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(AspNetUserRole);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserRole UserRole = db.AspNetUserRoles.Where(ur => ur.UserId == id).FirstOrDefault();
            if (UserRole == null)
            {
                return HttpNotFound();
            }
            return View(UserRole);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUserRole UserRole = db.AspNetUserRoles.Where(ur => ur.UserId == id).FirstOrDefault();
            db.AspNetUserRoles.Remove(UserRole);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}