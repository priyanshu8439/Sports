using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sports;

namespace Sports.Controllers
{
    public class Customer_infoController : Controller
    {
        private Sports_Zone_DbEntities db = new Sports_Zone_DbEntities();

        // GET: Customer_info
        public ActionResult Index()
        {
            var customer_info = db.Customer_info.Include(c => c.User).Include(c => c.Feedback);
            return View(customer_info.ToList());
        }

        // GET: Customer_info/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_info customer_info = db.Customer_info.Find(id);
            if (customer_info == null)
            {
                return HttpNotFound();
            }
            return View(customer_info);
        }

        // GET: Customer_info/Create
        public ActionResult Create()
        {
            ViewBag.CusId = new SelectList(db.Users, "userId", "password");
            ViewBag.CusId = new SelectList(db.Feedbacks, "CusId", "ProId");
            return View();
        }

        // POST: Customer_info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CusId,First_Name,Last_Name,Phone,Email,Address")] Customer_info customer_info)
        {
            if (ModelState.IsValid)
            {
                db.Customer_info.Add(customer_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CusId = new SelectList(db.Users, "userId", "password", customer_info.CusId);
            ViewBag.CusId = new SelectList(db.Feedbacks, "CusId", "ProId", customer_info.CusId);
            return View(customer_info);
        }

        // GET: Customer_info/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_info customer_info = db.Customer_info.Find(id);
            if (customer_info == null)
            {
                return HttpNotFound();
            }
            ViewBag.CusId = new SelectList(db.Users, "userId", "password", customer_info.CusId);
            ViewBag.CusId = new SelectList(db.Feedbacks, "CusId", "ProId", customer_info.CusId);
            return View(customer_info);
        }

        // POST: Customer_info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CusId,First_Name,Last_Name,Phone,Email,Address")] Customer_info customer_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CusId = new SelectList(db.Users, "userId", "password", customer_info.CusId);
            ViewBag.CusId = new SelectList(db.Feedbacks, "CusId", "ProId", customer_info.CusId);
            return View(customer_info);
        }

        // GET: Customer_info/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_info customer_info = db.Customer_info.Find(id);
            if (customer_info == null)
            {
                return HttpNotFound();
            }
            return View(customer_info);
        }

        // POST: Customer_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Customer_info customer_info = db.Customer_info.Find(id);
            db.Customer_info.Remove(customer_info);
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
