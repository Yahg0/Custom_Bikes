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
    public class QuadroesController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET
        public ActionResult Index()
        {
            return View(db.Quadros.ToList());
        }

        // GET
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quadro quadro = db.Quadros.Find(id);
            if (quadro == null)
            {
                return HttpNotFound();
            }
            return View(quadro);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuadroID,Nome,Preco")] Quadro quadro)
        {
            if (ModelState.IsValid)
            {
                db.Quadros.Add(quadro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quadro);
        }

        // GET
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quadro quadro = db.Quadros.Find(id);
            if (quadro == null)
            {
                return HttpNotFound();
            }
            return View(quadro);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuadroID,Nome,Preco")] Quadro quadro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quadro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quadro);
        }

        // GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quadro quadro = db.Quadros.Find(id);
            if (quadro == null)
            {
                return HttpNotFound();
            }
            return View(quadro);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quadro quadro = db.Quadros.Find(id);
            db.Quadros.Remove(quadro);
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
