using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Auth
{
    public class AdminAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var flag = base.AuthorizeCore(httpContext);
            if (flag)
            {
                var id = Int32.Parse(httpContext.User.Identity.Name);

                HMSEntities db = new HMSEntities();

                var ad = (from c in db.Admins
                          where c.Id == id
                          select c).FirstOrDefault();


                if (ad != null)
                    return true;

            }
            return false;
        }
    }
}