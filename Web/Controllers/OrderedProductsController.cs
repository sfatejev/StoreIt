using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Orders;
using DAL;

namespace Web.Controllers
{
    public class OrderedProductsController : Controller
    {
        private StoreItDbContext db = new StoreItDbContext();

        // GET: OrderedProducts
        public ActionResult Index()
        {
            var orderedProducts = db.OrderedProducts.Include(o => o.Order).Include(o => o.Product);
            return View(orderedProducts.ToList());
        }

        // GET: OrderedProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderedProduct orderedProduct = db.OrderedProducts.Find(id);
            if (orderedProduct == null)
            {
                return HttpNotFound();
            }
            return View(orderedProduct);
        }

        // GET: OrderedProducts/Create
        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: OrderedProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderedProductId,OrderedQuantity,OrderedPrice,OrderId,ProductId")] OrderedProduct orderedProduct)
        {
            if (ModelState.IsValid)
            {
                db.OrderedProducts.Add(orderedProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", orderedProduct.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", orderedProduct.ProductId);
            return View(orderedProduct);
        }

        // GET: OrderedProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderedProduct orderedProduct = db.OrderedProducts.Find(id);
            if (orderedProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", orderedProduct.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", orderedProduct.ProductId);
            return View(orderedProduct);
        }

        // POST: OrderedProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderedProductId,OrderedQuantity,OrderedPrice,OrderId,ProductId")] OrderedProduct orderedProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderedProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", orderedProduct.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", orderedProduct.ProductId);
            return View(orderedProduct);
        }

        // GET: OrderedProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderedProduct orderedProduct = db.OrderedProducts.Find(id);
            if (orderedProduct == null)
            {
                return HttpNotFound();
            }
            return View(orderedProduct);
        }

        // POST: OrderedProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderedProduct orderedProduct = db.OrderedProducts.Find(id);
            db.OrderedProducts.Remove(orderedProduct);
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
