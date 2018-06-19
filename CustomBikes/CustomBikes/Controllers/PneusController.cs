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
    public class PneusController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET
        public ActionResult Index()
        {
            return View(db.Pneus.ToList());
        }

        // GET
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pneu pneu = db.Pneus.Find(id);
            if (pneu == null)
            {
                return HttpNotFound();
            }
            return View(pneu);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PneuID,Nome,Preco")] Pneu pneu)
        {
            if (ModelState.IsValid)
            {
                db.Pneus.Add(pneu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pneu);
        }

        // GET
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pneu pneu = db.Pneus.Find(id);
            if (pneu == null)
            {
                return HttpNotFound();
            }
            return View(pneu);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PneuID,Nome,Preco")] Pneu pneu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pneu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pneu);
        }

        // GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pneu pneu = db.Pneus.Find(id);
            if (pneu == null)
            {
                return HttpNotFound();
            }
            return View(pneu);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pneu pneu = db.Pneus.Find(id);
            db.Pneus.Remove(pneu);
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
