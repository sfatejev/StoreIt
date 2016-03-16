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
    public class ProductEditsController : Controller
    {
        private StoreItDbContext db = new StoreItDbContext();

        // GET: ProductEdits
        public ActionResult Index()
        {
            var productEdits = db.ProductEdits.Include(p => p.Product).Include(p => p.ProductEditType);
            return View(productEdits.ToList());
        }

        // GET: ProductEdits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEdit productEdit = db.ProductEdits.Find(id);
            if (productEdit == null)
            {
                return HttpNotFound();
            }
            return View(productEdit);
        }

        // GET: ProductEdits/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.ProductEditTypeId = new SelectList(db.ProductEditTypes, "ProductEditTypeId", "ProductEditTypeValue");
            return View();
        }

        // POST: ProductEdits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductEditId,ProductEditTime,ProductEditorId,ProductEditTypeId,ProductId")] ProductEdit productEdit)
        {
            if (ModelState.IsValid)
            {
                db.ProductEdits.Add(productEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", productEdit.ProductId);
            ViewBag.ProductEditTypeId = new SelectList(db.ProductEditTypes, "ProductEditTypeId", "ProductEditTypeValue", productEdit.ProductEditTypeId);
            return View(productEdit);
        }

        // GET: ProductEdits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEdit productEdit = db.ProductEdits.Find(id);
            if (productEdit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", productEdit.ProductId);
            ViewBag.ProductEditTypeId = new SelectList(db.ProductEditTypes, "ProductEditTypeId", "ProductEditTypeValue", productEdit.ProductEditTypeId);
            return View(productEdit);
        }

        // POST: ProductEdits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductEditId,ProductEditTime,ProductEditorId,ProductEditTypeId,ProductId")] ProductEdit productEdit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productEdit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", productEdit.ProductId);
            ViewBag.ProductEditTypeId = new SelectList(db.ProductEditTypes, "ProductEditTypeId", "ProductEditTypeValue", productEdit.ProductEditTypeId);
            return View(productEdit);
        }

        // GET: ProductEdits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEdit productEdit = db.ProductEdits.Find(id);
            if (productEdit == null)
            {
                return HttpNotFound();
            }
            return View(productEdit);
        }

        // POST: ProductEdits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductEdit productEdit = db.ProductEdits.Find(id);
            db.ProductEdits.Remove(productEdit);
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
