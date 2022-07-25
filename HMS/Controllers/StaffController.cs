using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Auth;
using HMS.Models;


namespace HMS.Controllers
{
    [StaffAccess]
    [Authorize]
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            var db = new HMSEntities();
            var id = Int32.Parse(Session["logged_user"].ToString());
            var st = (from s in db.StaffTasks
                      where s.StaffID == id && s.Status==0
                      select s);
            return View(st);
        }
        // task done delete
        public ActionResult TaskDone(int id)
        {
            if (ModelState.IsValid) {
                var db = new HMSEntities();
                var st = (from s in db.StaffTasks
                          where s.ID == id
                          select s).FirstOrDefault();
                st.Status = 1;
                db.SaveChanges();
            }
                
            return RedirectToAction("Index");
        }

        public ActionResult Profile()
        {
            var db = new HMSEntities();
            var id = Int32.Parse(Session["logged_user"].ToString());
            var st = (from s in db.Staffs
                      select s);
            return View(st);
        }

        //calgro list
        public ActionResult CalGro()
        {
            HMSEntities db = new HMSEntities();
            var list = (from s in db.CalGros
                         select s);
            return View(list);             
        }

        // calgro create
        [HttpPost]

        public ActionResult CalGro(CalGro e)
        {
            if (ModelState.IsValid) {
                HMSEntities db = new HMSEntities();
                var list = (from s in db.CalGros
                            select s);
                db.CalGros.Add(e);
                db.SaveChanges();
                return View(list);
            }
            return RedirectToAction("CalGro");

        }
        
        //inout note list
        public ActionResult In_out_note()
        {
            HMSEntities db = new HMSEntities();
            var notes = (from s in db.In_out_notes
                         select s);
            return View(notes);
        }

        //inout note create
        [HttpPost]
        public ActionResult In_out_note(In_out_notes e)
        {
            if (ModelState.IsValid) {
                HMSEntities db = new HMSEntities();
                var notes = (from s in db.In_out_notes
                             select s);
                db.In_out_notes.Add(e);
                db.SaveChanges();
                return View(notes);
            }
            return RedirectToAction("In_out_note");
        }

        //in_out_note_edit form
        public ActionResult In_out_note_edit(int id)
        {
            if (ModelState.IsValid)
            {
                HMSEntities db = new HMSEntities();
                var notes = (from s in db.In_out_notes where s.Id == id select s).FirstOrDefault();
                return View(notes);
            }
            return RedirectToAction("In_out_note_edit");
        }

        //in_out_note_edit
        [HttpPost]
        public ActionResult In_out_note_edit(In_out_notes e)
        {
            if (ModelState.IsValid)
            {
                HMSEntities db = new HMSEntities();
                var notes = (from s in db.In_out_notes where s.Id == e.Id select s).FirstOrDefault();
                notes.Member_id = e.Member_id;
                notes.Status = e.Status;
                db.SaveChanges();
                return RedirectToAction("In_out_note");
            }
        }
        //in out note delete

        public ActionResult In_out_note_delete(int id)
        {
            HMSEntities db = new HMSEntities();
            var st = (from s in db.In_out_notes where s.Id == id select s).SingleOrDefault();
            db.In_out_notes.Remove(st);
            db.SaveChanges();
            return RedirectToAction("In_out_note");
        }

        //see room details
        public ActionResult Roomdetail()
        {
            HMSEntities db = new HMSEntities();
            var list = (from s in db.RoomDetails
                        select s);
            return View(list);
        }
        //Room details submition
        [HttpPost]
        public ActionResult Roomdetail(RoomDetail e)
        {
            if (ModelState.IsValid)
            {
                HMSEntities db = new HMSEntities();
                var detail = (from s in db.RoomDetails
                              select s);
                db.RoomDetails.Add(e);
                db.SaveChanges();
                return View(detail);
            }
            return View("RoomDetails");
        }

        //meal info list
        public ActionResult MealInfo()
        {
            HMSEntities db = new HMSEntities();
            var list = (from s in db.MealIinfos
                        select s);
            return View(list);
        }

        //Request_Service
        public ActionResult Request_Services()
        {
            HMSEntities db = new HMSEntities();
            var list = (from s in db.Request_Services
                        select s);
            return View(list);
        }
        //Request_Service_Update_Form
        public ActionResult Request_Service_Update(int id)
        {
            HMSEntities db = new HMSEntities();
            var update = (from s in db.Request_Services where s.Id == id select s).FirstOrDefault();
            return View(update);
        }
        //Request_Service_Update
        [HttpPost]
        public ActionResult Request_Service_Update(Request_Services r)
        {
            HMSEntities db = new HMSEntities();
            var update = (from s in db.Request_Services where s.Id == r.Id select s).FirstOrDefault();

            update.Status = r.Status;
            db.SaveChanges();
            return RedirectToAction("Request_Services");
        }


    }
}
