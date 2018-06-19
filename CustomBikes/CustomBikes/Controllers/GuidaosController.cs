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
    public class GuidaosController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET
        public ActionResult Index()
        {
            return View(db.Guidoes.ToList());
        }

        // GET
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guidao guidao = db.Guidoes.Find(id);
            if (guidao == null)
            {
                return HttpNotFound();
            }
            return View(guidao);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GuidaoID,Nome,Preco")] Guidao guidao)
        {
            if (ModelState.IsValid)
            {
                db.Guidoes.Add(guidao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guidao);
        }

        // GET
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guidao guidao = db.Guidoes.Find(id);
            if (guidao == null)
            {
                return HttpNotFound();
            }
            return View(guidao);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GuidaoID,Nome,Preco")] Guidao guidao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guidao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guidao);
        }

        // GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guidao guidao = db.Guidoes.Find(id);
            if (guidao == null)
            {
                return HttpNotFound();
            }
            return View(guidao);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guidao guidao = db.Guidoes.Find(id);
            db.Guidoes.Remove(guidao);
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
