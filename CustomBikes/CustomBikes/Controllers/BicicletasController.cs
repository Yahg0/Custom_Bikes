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
    public class BicicletasController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET: Bicicletas
        public ActionResult Index()
        {
            var bicicletas = db.Bicicletas.Include(b => b._Aro).Include(b => b._Banco).Include(b => b._Categoria).Include(b => b._Guidao).Include(b => b._Pneu).Include(b => b._Quadro);
            return View(bicicletas.ToList());
        }

        // GET
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicicleta bicicleta = db.Bicicletas.Find(id);
            if (bicicleta == null)
            {
                return HttpNotFound();
            }
            return View(bicicleta);
        }

        // GET
        public ActionResult Create()
        {
            ViewBag.AroID = new SelectList(db.Aros, "AroID", "Nome");
            ViewBag.BancoID = new SelectList(db.Bancos, "BancoID", "Nome");
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome");
            ViewBag.GuidaoID = new SelectList(db.Guidoes, "GuidaoID", "Nome");
            ViewBag.PneuID = new SelectList(db.Pneus, "PneuID", "Nome");
            ViewBag.QuadroID = new SelectList(db.Quadros, "QuadroID", "Nome");
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BicicletaID,Nome,AroID,BancoID,CategoriaID,GuidaoID,PneuID,QuadroID")] Bicicleta bicicleta)
        {
            if (ModelState.IsValid)
            {
                db.Bicicletas.Add(bicicleta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AroID = new SelectList(db.Aros, "AroID", "Nome", bicicleta.AroID);
            ViewBag.BancoID = new SelectList(db.Bancos, "BancoID", "Nome", bicicleta.BancoID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", bicicleta.CategoriaID);
            ViewBag.GuidaoID = new SelectList(db.Guidoes, "GuidaoID", "Nome", bicicleta.GuidaoID);
            ViewBag.PneuID = new SelectList(db.Pneus, "PneuID", "Nome", bicicleta.PneuID);
            ViewBag.QuadroID = new SelectList(db.Quadros, "QuadroID", "Nome", bicicleta.QuadroID);
            return View(bicicleta);
        }

        // GET
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicicleta bicicleta = db.Bicicletas.Find(id);
            if (bicicleta == null)
            {
                return HttpNotFound();
            }
            ViewBag.AroID = new SelectList(db.Aros, "AroID", "Nome", bicicleta.AroID);
            ViewBag.BancoID = new SelectList(db.Bancos, "BancoID", "Nome", bicicleta.BancoID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", bicicleta.CategoriaID);
            ViewBag.GuidaoID = new SelectList(db.Guidoes, "GuidaoID", "Nome", bicicleta.GuidaoID);
            ViewBag.PneuID = new SelectList(db.Pneus, "PneuID", "Nome", bicicleta.PneuID);
            ViewBag.QuadroID = new SelectList(db.Quadros, "QuadroID", "Nome", bicicleta.QuadroID);
            return View(bicicleta);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BicicletaID,Nome,AroID,BancoID,CategoriaID,GuidaoID,PneuID,QuadroID")] Bicicleta bicicleta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bicicleta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AroID = new SelectList(db.Aros, "AroID", "Nome", bicicleta.AroID);
            ViewBag.BancoID = new SelectList(db.Bancos, "BancoID", "Nome", bicicleta.BancoID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", bicicleta.CategoriaID);
            ViewBag.GuidaoID = new SelectList(db.Guidoes, "GuidaoID", "Nome", bicicleta.GuidaoID);
            ViewBag.PneuID = new SelectList(db.Pneus, "PneuID", "Nome", bicicleta.PneuID);
            ViewBag.QuadroID = new SelectList(db.Quadros, "QuadroID", "Nome", bicicleta.QuadroID);
            return View(bicicleta);
        }

        // GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicicleta bicicleta = db.Bicicletas.Find(id);
            if (bicicleta == null)
            {
                return HttpNotFound();
            }
            return View(bicicleta);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bicicleta bicicleta = db.Bicicletas.Find(id);
            db.Bicicletas.Remove(bicicleta);
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
