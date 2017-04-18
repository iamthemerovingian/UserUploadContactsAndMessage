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
        public ActionResult Index(UserDetail userDetails)
        {
            var details = _db.UserDetails.Where(row => row.Name ==userDetails.Name && row.SendDateTime.Equals(userDetails.SendDateTime)).FirstOrDefault();

            return View("Create", details);
        }

        // GET: UserDetails/Details/5
        [HttpGet]
        public ActionResult Confirm(UserDetail details)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //UserDetail userDetail = _db.UserDetails.Find(id);
            //if (userDetail == null)
            //{
            //    return HttpNotFound();
            //}
            return View(details);
        }
        [HttpPost]
        public ActionResult Confirm(UserDetail details, bool confirmed)
        {
            if (confirmed)
            {
                _db.UserDetails.Add(details);
                _db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(details);
        }

        // GET: UserDetails/Create
        [HttpGet]
        public ActionResult Create()
        {
            //var lastUserEntry = (from u in _db.UserDetails
            //                     orderby u.Id descending
            //                     select u).FirstOrDefault();

            // return View(lastUserEntry);
            UserDetailViewModel user = new UserDetailViewModel(){ SendDateTime = DateTime.Now };
            return View(user);
        }

        // POST: UserDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Message,Contacts")] UserDetailViewModel userDetailVM)
        {
            try
            {
                userDetailVM.user.SendDateTime = DateTime.Now;

                if (ModelState.IsValid)
                {
                    return RedirectToAction("Confirm", userDetailVM.user);
                }
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
            }
            
            return View(userDetailVM);
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
