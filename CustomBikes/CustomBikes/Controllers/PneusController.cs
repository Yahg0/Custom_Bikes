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

        // GET: Pneus
        public ActionResult Index()
        {
            // Conecta o banco
            MeuContexto contexto = new MeuContexto();

            List<Pneu> pneus = contexto.Pneus.ToList();
            return View(pneus);
        }


        // GET: Pneus create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pneus create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pneu pneu)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Pneus.Add(pneu);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pneu);
        }

        // ===============================================================
        // Detalhes

        // Get
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            //Pesquisa no banco e retorna pra view
            Pneu pn = contexto.Pneus.Find(id);

            if (pn == null)
            {
                return HttpNotFound();
            }

            return View(pn);

        }

        // ===============================================================
        // Edição

        // GET
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            //Pesquisa no banco e retorna pra view
            Pneu pn = contexto.Pneus.Find(id);

            if (pn == null)
            {
                return HttpNotFound();
            }

            return View(pn);

        }

        //Edição
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pneu pn)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(pn).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(pn);
        }

        // ===============================================================
        // Exclusão

        //GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MeuContexto contexto = new MeuContexto();

            //Pesquisa no banco e retorna pra view
            Pneu pn = contexto.Pneus.Find(id);

            if (pn == null)
            {
                return HttpNotFound();
            }

            return View(pn);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            MeuContexto contexto = new MeuContexto();

            Pneu pn = contexto.Pneus.Find(id);
            contexto.Pneus.Remove(pn);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
