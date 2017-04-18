using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserUploadContactsAndMessage.Models;

namespace UserUploadContactsAndMessage.Controllers
{
    public class UserDetailsController : Controller
    {
        private UserUploadContactsAndMessageDb _db = new UserUploadContactsAndMessageDb();

        // GET: UserDetails
        public ActionResult Index()
        {
            return View(_db.UserDetails.ToList());
        }

        // GET: UserDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = _db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

        // GET: UserDetails/Create
        [HttpGet]
        public ActionResult Create()
        {
            //var lastUserEntry = (from u in _db.UserDetails
            //                     orderby u.Id descending
            //                     select u).FirstOrDefault();

            // return View(lastUserEntry);
            UserDetail user = new UserDetail(){ SendDateTime = DateTime.Now };
            return View(user);
        }

        // POST: UserDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Message,Contacts")] UserDetail userDetail)
        {
            try
            {
                userDetail.SendDateTime = DateTime.Now;

                if (ModelState.IsValid)
                {
                    _db.UserDetails.Add(userDetail);
                    _db.SaveChanges();
                    return RedirectToAction("Create");
                }
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
            }
            
            return View(userDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
