using MbmStore.DAL;
using MbmStore.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MbmStore.Areas.Admin.Controllers
{
    public class MusicController : Controller
    {
        private MbmStoreContext db = new MbmStoreContext();

        // GET: Admin/Music
        public ActionResult Index()
        {
            return View(db.MusicCDs.ToList());
        }

        // GET: Admin/Music/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicCD musicCD = db.MusicCDs.Find(id);
            if (musicCD == null)
            {
                return HttpNotFound();
            }
            return View(musicCD);
        }

        // GET: Admin/Music/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Music/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Title,Price,ImageUrl,Category,Artist,Label,Released")] MusicCD musicCD)
        {
            if (ModelState.IsValid)
            {
                db.MusicCDs.Add(musicCD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musicCD);
        }

        // GET: Admin/Music/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicCD musicCD = db.MusicCDs.Find(id);
            if (musicCD == null)
            {
                return HttpNotFound();
            }
            return View(musicCD);
        }

        // POST: Admin/Music/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Title,Price,ImageUrl,Category,Artist,Label,Released")] MusicCD musicCD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musicCD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musicCD);
        }

        // GET: Admin/Music/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicCD musicCD = db.MusicCDs.Find(id);
            if (musicCD == null)
            {
                return HttpNotFound();
            }
            return View(musicCD);
        }

        // POST: Admin/Music/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusicCD musicCD = db.MusicCDs.Find(id);
            db.MusicCDs.Remove(musicCD);
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
