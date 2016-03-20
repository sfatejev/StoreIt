using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL;
using Domain.Orders;

namespace Web.Controllers.Orders
{
    public class OrderEditTypesController : Controller
    {
        private StoreItDbContext db = new StoreItDbContext();

        // GET: OrderEditTypes
        public ActionResult Index()
        {
            return View(db.OrderEditTypes.ToList());
        }

        // GET: OrderEditTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderEditType orderEditType = db.OrderEditTypes.Find(id);
            if (orderEditType == null)
            {
                return HttpNotFound();
            }
            return View(orderEditType);
        }

        // GET: OrderEditTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderEditTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderEditTypeId,OrderEditTypeValue,OrderEditTypeDescription,OrderEditTypeActive")] OrderEditType orderEditType)
        {
            if (ModelState.IsValid)
            {
                db.OrderEditTypes.Add(orderEditType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderEditType);
        }

        // GET: OrderEditTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderEditType orderEditType = db.OrderEditTypes.Find(id);
            if (orderEditType == null)
            {
                return HttpNotFound();
            }
            return View(orderEditType);
        }

        // POST: OrderEditTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderEditTypeId,OrderEditTypeValue,OrderEditTypeDescription,OrderEditTypeActive")] OrderEditType orderEditType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderEditType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderEditType);
        }

        // GET: OrderEditTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderEditType orderEditType = db.OrderEditTypes.Find(id);
            if (orderEditType == null)
            {
                return HttpNotFound();
            }
            return View(orderEditType);
        }

        // POST: OrderEditTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderEditType orderEditType = db.OrderEditTypes.Find(id);
            db.OrderEditTypes.Remove(orderEditType);
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
