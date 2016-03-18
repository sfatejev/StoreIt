using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL;
using Domain.People;

namespace Web.Areas.People.Controllers
{
    public class PersonTypesController : Controller
    {
        private StoreItDbContext db = new StoreItDbContext();

        // GET: PersonTypes
        public ActionResult Index()
        {
            return View(db.PersonTypes.ToList());
        }

        // GET: PersonTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonType personType = db.PersonTypes.Find(id);
            if (personType == null)
            {
                return HttpNotFound();
            }
            return View(personType);
        }

        // GET: PersonTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonTypeId,PersonTypeValue,PersonTypeDescription,PersonTypeActive")] PersonType personType)
        {
            if (ModelState.IsValid)
            {
                db.PersonTypes.Add(personType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personType);
        }

        // GET: PersonTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonType personType = db.PersonTypes.Find(id);
            if (personType == null)
            {
                return HttpNotFound();
            }
            return View(personType);
        }

        // POST: PersonTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonTypeId,PersonTypeValue,PersonTypeDescription,PersonTypeActive")] PersonType personType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personType);
        }

        // GET: PersonTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonType personType = db.PersonTypes.Find(id);
            if (personType == null)
            {
                return HttpNotFound();
            }
            return View(personType);
        }

        // POST: PersonTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonType personType = db.PersonTypes.Find(id);
            db.PersonTypes.Remove(personType);
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
