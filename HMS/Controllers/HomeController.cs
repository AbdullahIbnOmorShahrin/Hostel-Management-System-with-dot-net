using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HMS.Models;

namespace HMS.Controllers
{


    public class HomeController : Controller
    {


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Admin e)
        {

            HMSEntities db = new HMSEntities();
            var ad = (from s in db.Admins
                      where s.Id.Equals(e.Id)
                      && s.Password.Equals(e.Password)
                      && s.Type.Equals(1)
                      select s).SingleOrDefault();


            var mem = (from s in db.Members
                       where s.Id.Equals(e.Id)
                       && s.Password.Equals(e.Password)
                        && s.Type.Equals(2)
                       select s).SingleOrDefault();

            var staff = (from s in db.Staffs
                         where s.Id.Equals(e.Id)
                         && s.Password.Equals(e.Password)
                          && s.Type.Equals(3)
                         select s).SingleOrDefault();





            if (ad != null)
            {
                FormsAuthentication.SetAuthCookie(ad.Id.ToString(), true);
                Session["logged_user"] = ad.Id;

                return RedirectToAction("Index", "Admin");
            }
            else if (mem != null)
            {
                FormsAuthentication.SetAuthCookie(mem.Id.ToString(), true);
                Session["logged_user"] = mem.Id;
                return RedirectToAction("Index", "Member");
            }
            else if (staff != null)
            {
                FormsAuthentication.SetAuthCookie(staff.Id.ToString(), true);
                Session["logged_user"] = staff.Id;
                return RedirectToAction("Index", "Staff");
            }

            TempData["msg"] = "User Does not exist";
            return View();

        }

        public ActionResult Logout()
        {
            Session.Remove("logged_user");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}