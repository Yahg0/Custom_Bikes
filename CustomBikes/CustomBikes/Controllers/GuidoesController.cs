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
    public class GuidoesController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET: Guidoes
        public ActionResult Index()
        {
            // Conecta o banco
            MeuContexto contexto = new MeuContexto();

            List<Guidao> guidoes = contexto.Guidoes.ToList();
            return View(guidoes);
        }


        // GET: Guidoes create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guidoes create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Guidao guidao)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Guidoes.Add(guidao);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guidao);
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
            Guidao gui = contexto.Guidoes.Find(id);

            if (gui == null)
            {
                return HttpNotFound();
            }

            return View(gui);

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
            Guidao gui = contexto.Guidoes.Find(id);

            if (gui == null)
            {
                return HttpNotFound();
            }

            return View(gui);

        }

        //Edição
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guidao gui)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(gui).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(gui);
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
            Guidao gui = contexto.Guidoes.Find(id);

            if (gui == null)
            {
                return HttpNotFound();
            }

            return View(gui);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            MeuContexto contexto = new MeuContexto();

            Guidao gui = contexto.Guidoes.Find(id);
            contexto.Guidoes.Remove(gui);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
