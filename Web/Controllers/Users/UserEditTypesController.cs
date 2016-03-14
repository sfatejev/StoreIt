using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Users;
using StoreIt;

namespace Web.Controllers.Users
{
    public class UserEditTypesController : Controller
    {
        private StoreItDbContext db = new StoreItDbContext();

        // GET: UserEditTypes
        public ActionResult Index()
        {
            return View(db.UserEditTypes.ToList());
        }

        // GET: UserEditTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEditType userEditType = db.UserEditTypes.Find(id);
            if (userEditType == null)
            {
                return HttpNotFound();
            }
            return View(userEditType);
        }

        // GET: UserEditTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserEditTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserEditTypeId,UserEditTypeValue,UserEditTypeDescription,UserEditTypeActive")] UserEditType userEditType)
        {
            if (ModelState.IsValid)
            {
                db.UserEditTypes.Add(userEditType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userEditType);
        }

        // GET: UserEditTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEditType userEditType = db.UserEditTypes.Find(id);
            if (userEditType == null)
            {
                return HttpNotFound();
            }
            return View(userEditType);
        }

        // POST: UserEditTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserEditTypeId,UserEditTypeValue,UserEditTypeDescription,UserEditTypeActive")] UserEditType userEditType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userEditType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userEditType);
        }

        // GET: UserEditTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEditType userEditType = db.UserEditTypes.Find(id);
            if (userEditType == null)
            {
                return HttpNotFound();
            }
            return View(userEditType);
        }

        // POST: UserEditTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserEditType userEditType = db.UserEditTypes.Find(id);
            db.UserEditTypes.Remove(userEditType);
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
