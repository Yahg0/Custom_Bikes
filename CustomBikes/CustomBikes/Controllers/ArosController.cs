using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomBikes.Models;
using CustomBikes.Models.DAL;

namespace CustomBikes.Controllers
{
    public class ArosController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET: Aros
        public ActionResult Index()
        {
            return View(db.Aros.ToList());
        }

        // GET
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aro aro = db.Aros.Find(id);
            if (aro == null)
            {
                return HttpNotFound();
            }
            return View(aro);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AroID,Nome,Preco")] Aro aro)
        {
            if (ModelState.IsValid)
            {
                db.Aros.Add(aro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aro);
        }

        // GET
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aro aro = db.Aros.Find(id);
            if (aro == null)
            {
                return HttpNotFound();
            }
            return View(aro);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AroID,Nome,Preco")] Aro aro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aro);
        }

        // GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aro aro = db.Aros.Find(id);
            if (aro == null)
            {
                return HttpNotFound();
            }
            return View(aro);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aro aro = db.Aros.Find(id);
            db.Aros.Remove(aro);
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
