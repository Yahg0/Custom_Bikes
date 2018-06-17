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
            // Conecta o banco
            MeuContexto contexto = new MeuContexto();

            List<Aro> aros = contexto.Aros.ToList();
            return View(aros);
        }


        // GET: Aros create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aros create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aro aro)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Aros.Add(aro);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aro);
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
            Aro ar = contexto.Aros.Find(id);

            if (ar == null)
            {
                return HttpNotFound();
            }

            return View(ar);

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
            Aro ar = contexto.Aros.Find(id);

            if (ar == null)
            {
                return HttpNotFound();
            }

            return View(ar);

        }

        //Edição
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aro ar)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(ar).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(ar);
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
            Aro ar = contexto.Aros.Find(id);

            if (ar == null)
            {
                return HttpNotFound();
            }

            return View(ar);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            MeuContexto contexto = new MeuContexto();

            Aro ar = contexto.Aros.Find(id);
            contexto.Aros.Remove(ar);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
