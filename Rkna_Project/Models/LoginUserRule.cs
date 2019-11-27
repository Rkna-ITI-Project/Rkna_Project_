using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public  static class LoginUserRule
    {
        private static string CurrRule { get; set; }


        public static void SetRule( string Rule)
        {
            CurrRule = Rule;
        }
        public static string GetCurrentUserRule(this HtmlHelper  html )
        {
            return CurrRule;
        }
    }
}