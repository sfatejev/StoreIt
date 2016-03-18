using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL;
using Domain.Orders;

namespace Web.Controllers.Orders
{
    public class OrderEditsController : Controller
    {
        private StoreItDbContext db = new StoreItDbContext();

        // GET: OrderEdits
        public ActionResult Index()
        {
            var orderEdits = db.OrderEdits.Include(o => o.Order).Include(o => o.OrderEditType).Include(o => o.User);
            return View(orderEdits.ToList());
        }

        // GET: OrderEdits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderEdit orderEdit = db.OrderEdits.Find(id);
            if (orderEdit == null)
            {
                return HttpNotFound();
            }
            return View(orderEdit);
        }

        // GET: OrderEdits/Create
        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId");
            ViewBag.OrderEditTypeId = new SelectList(db.OrderEditTypes, "OrderEditTypeId", "OrderEditTypeValue");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username");
            return View();
        }

        // POST: OrderEdits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderEditId,OrderEditTime,OrderEditTypeId,UserId,OrderId")] OrderEdit orderEdit)
        {
            if (ModelState.IsValid)
            {
                db.OrderEdits.Add(orderEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", orderEdit.OrderId);
            ViewBag.OrderEditTypeId = new SelectList(db.OrderEditTypes, "OrderEditTypeId", "OrderEditTypeValue", orderEdit.OrderEditTypeId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", orderEdit.UserId);
            return View(orderEdit);
        }

        // GET: OrderEdits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderEdit orderEdit = db.OrderEdits.Find(id);
            if (orderEdit == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", orderEdit.OrderId);
            ViewBag.OrderEditTypeId = new SelectList(db.OrderEditTypes, "OrderEditTypeId", "OrderEditTypeValue", orderEdit.OrderEditTypeId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", orderEdit.UserId);
            return View(orderEdit);
        }

        // POST: OrderEdits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderEditId,OrderEditTime,OrderEditTypeId,UserId,OrderId")] OrderEdit orderEdit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderEdit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", orderEdit.OrderId);
            ViewBag.OrderEditTypeId = new SelectList(db.OrderEditTypes, "OrderEditTypeId", "OrderEditTypeValue", orderEdit.OrderEditTypeId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", orderEdit.UserId);
            return View(orderEdit);
        }

        // GET: OrderEdits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderEdit orderEdit = db.OrderEdits.Find(id);
            if (orderEdit == null)
            {
                return HttpNotFound();
            }
            return View(orderEdit);
        }

        // POST: OrderEdits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderEdit orderEdit = db.OrderEdits.Find(id);
            db.OrderEdits.Remove(orderEdit);
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
