using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Store;
using DAL;

namespace Web.Controllers.Store
{
    public class ProductEditTypesController : Controller
    {
        private StoreItDbContext db = new StoreItDbContext();

        // GET: ProductEditTypes
        public ActionResult Index()
        {
            return View(db.ProductEditTypes.ToList());
        }

        // GET: ProductEditTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEditType productEditType = db.ProductEditTypes.Find(id);
            if (productEditType == null)
            {
                return HttpNotFound();
            }
            return View(productEditType);
        }

        // GET: ProductEditTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductEditTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductEditTypeId,ProductEditTypeValue,ProductEditTypeActive")] ProductEditType productEditType)
        {
            if (ModelState.IsValid)
            {
                db.ProductEditTypes.Add(productEditType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productEditType);
        }

        // GET: ProductEditTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEditType productEditType = db.ProductEditTypes.Find(id);
            if (productEditType == null)
            {
                return HttpNotFound();
            }
            return View(productEditType);
        }

        // POST: ProductEditTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductEditTypeId,ProductEditTypeValue,ProductEditTypeActive")] ProductEditType productEditType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productEditType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productEditType);
        }

        // GET: ProductEditTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEditType productEditType = db.ProductEditTypes.Find(id);
            if (productEditType == null)
            {
                return HttpNotFound();
            }
            return View(productEditType);
        }

        // POST: ProductEditTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductEditType productEditType = db.ProductEditTypes.Find(id);
            db.ProductEditTypes.Remove(productEditType);
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
