using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HMS.Auth
{
    public class StaffAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var flag = base.AuthorizeCore(httpContext);
            if (flag)
            {
                var id = Int32.Parse(httpContext.User.Identity.Name);
                //                httpContext.User.Identity.IsAuthenticated
                HMSEntities db = new HMSEntities();

                var st = (from c in db.Staffs
                          where c.Id == id
                          select c).FirstOrDefault();


                if (st != null)
                    return true;

            }
            return false;
        }
    }
}