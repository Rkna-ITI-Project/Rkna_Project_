using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Rkna_Project;
using Rkna_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public  static class LoginUserRule
    {
        static Rkna_DataBaseEntities db;
        static ApplicationUser user;
        static AspNetUserRole UserRule;
        private static string CurrRule { get; set; }


        public static void SetRule( string Rule)
        {
          
                CurrRule = Rule; 
        }
        public static string GetCurrentUserRule(this HtmlHelper  html )
        {
             db = new Rkna_DataBaseEntities();
             user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (user != null)
            {
                UserRule = db.AspNetUserRoles.Where(r => r.UserId == user.Id).FirstOrDefault();
            }

            if (UserRule!=null)
            { return UserRule.RoleId; }
            else
            { return CurrRule; }
        }
    }
}