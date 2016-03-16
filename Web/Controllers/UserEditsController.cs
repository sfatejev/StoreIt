using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Users;
using DAL;

namespace Web.Controllers.Users
{
    public class UserEditsController : Controller
    {
        private StoreItDbContext db = new StoreItDbContext();

        // GET: UserEdits
        public ActionResult Index()
        {
            var userEdits = db.UserEdits.Include(u => u.UserEditType);
            return View(userEdits.ToList());
        }

        // GET: UserEdits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEdit userEdit = db.UserEdits.Find(id);
            if (userEdit == null)
            {
                return HttpNotFound();
            }
            return View(userEdit);
        }

        // GET: UserEdits/Create
        public ActionResult Create()
        {
            ViewBag.UserEditTypeId = new SelectList(db.UserEditTypes, "UserEditTypeId", "UserEditTypeValue");
            return View();
        }

        // POST: UserEdits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserEditId,UserEditTime,UserEditorId,UserId,UserEditTypeId")] UserEdit userEdit)
        {
            if (ModelState.IsValid)
            {
                db.UserEdits.Add(userEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserEditTypeId = new SelectList(db.UserEditTypes, "UserEditTypeId", "UserEditTypeValue", userEdit.UserEditTypeId);
            return View(userEdit);
        }

        // GET: UserEdits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEdit userEdit = db.UserEdits.Find(id);
            if (userEdit == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserEditTypeId = new SelectList(db.UserEditTypes, "UserEditTypeId", "UserEditTypeValue", userEdit.UserEditTypeId);
            return View(userEdit);
        }

        // POST: UserEdits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserEditId,UserEditTime,UserEditorId,UserId,UserEditTypeId")] UserEdit userEdit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userEdit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserEditTypeId = new SelectList(db.UserEditTypes, "UserEditTypeId", "UserEditTypeValue", userEdit.UserEditTypeId);
            return View(userEdit);
        }

        // GET: UserEdits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEdit userEdit = db.UserEdits.Find(id);
            if (userEdit == null)
            {
                return HttpNotFound();
            }
            return View(userEdit);
        }

        // POST: UserEdits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserEdit userEdit = db.UserEdits.Find(id);
            db.UserEdits.Remove(userEdit);
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
