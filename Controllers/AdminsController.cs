using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Sports;

namespace Sports.Controllers
{
    public class AdminsController : Controller
    {
        private Sports_Zone_DbEntities db = new Sports_Zone_DbEntities();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model)
        {
            using (var context = new Sports_Zone_DbEntities())
            {
                bool isValid = context.Admins.Any(x => x.AdmName == model.AdmName && x.AdmPassword == model.AdmPassword);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.AdmName, false);
                    return RedirectToAction("Index", "Admins");
                }
                ModelState.AddModelError("", "Invalid Username or Password");
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        // GET: Admins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdmId,AdmName,AdmEmail,AdmPassword")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // GET: Admins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdmId,AdmName,AdmEmail,AdmPassword")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        // GET: Admins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
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

//        public ActionResult Index()
//        {

//            return View();
//        }
//        [HttpGet]
//        public ActionResult SignIn()
//        {
//            return View(new Sports.Admin());
//        }
//        [HttpPost]
//        public ActionResult SignIn(Sports.Admin obj)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(obj);
//            }
//            else
//            {
//                using (var context = new Sports_Zone_DbEntities())
//                {
//                    Sports.Admin admin = context.Admins.Where(u => u.AdmEmail == obj.AdmEmail && u.AdmPassword == obj.AdmPassword).FirstOrDefault();
//                    if (admin != null)
//                    {
//                        Session["AdminEmail"] = admin.AdmEmail;

//                        return RedirectToAction("Index", "Admins");

//                    }
//                    else
//                    {
//                        ModelState.AddModelError("", "Invalid user Email or Password");
//                        return View(obj);
//                    }
//                }
//            }
//        }
//    }
//}
