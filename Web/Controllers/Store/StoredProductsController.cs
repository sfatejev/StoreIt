using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Store;
using StoreIt;

namespace Web.Controllers.Store
{
    public class StoredProductsController : Controller
    {
        private StoreItDbContext db = new StoreItDbContext();

        // GET: StoredProducts
        public ActionResult Index()
        {
            var storedProducts = db.StoredProducts.Include(s => s.Product).Include(s => s.Storage);
            return View(storedProducts.ToList());
        }

        // GET: StoredProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoredProduct storedProduct = db.StoredProducts.Find(id);
            if (storedProduct == null)
            {
                return HttpNotFound();
            }
            return View(storedProduct);
        }

        // GET: StoredProducts/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "StorageName");
            return View();
        }

        // POST: StoredProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoredProductId,Quantity,StorageId,ProductId")] StoredProduct storedProduct)
        {
            if (ModelState.IsValid)
            {
                db.StoredProducts.Add(storedProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", storedProduct.ProductId);
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "StorageName", storedProduct.StorageId);
            return View(storedProduct);
        }

        // GET: StoredProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoredProduct storedProduct = db.StoredProducts.Find(id);
            if (storedProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", storedProduct.ProductId);
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "StorageName", storedProduct.StorageId);
            return View(storedProduct);
        }

        // POST: StoredProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoredProductId,Quantity,StorageId,ProductId")] StoredProduct storedProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storedProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", storedProduct.ProductId);
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "StorageName", storedProduct.StorageId);
            return View(storedProduct);
        }

        // GET: StoredProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoredProduct storedProduct = db.StoredProducts.Find(id);
            if (storedProduct == null)
            {
                return HttpNotFound();
            }
            return View(storedProduct);
        }

        // POST: StoredProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoredProduct storedProduct = db.StoredProducts.Find(id);
            db.StoredProducts.Remove(storedProduct);
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
