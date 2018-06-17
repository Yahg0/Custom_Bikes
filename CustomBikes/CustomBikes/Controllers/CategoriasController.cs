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
    public class CategoriasController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET: Categorias
        public ActionResult Index()
        {
            // Conecta o banco
            MeuContexto contexto = new MeuContexto();

            List<Categoria> categorias = contexto.Categorias.ToList();
            return View(categorias);
        }


        // GET: Categorias create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Categorias.Add(categoria);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
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
            Categoria cat = contexto.Categorias.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }

            return View(cat);

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
            Categoria cat = contexto.Categorias.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }

            return View(cat);

        }

        //Edição
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria cat)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(cat);
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
            Categoria cat = contexto.Categorias.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }

            return View(cat);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            MeuContexto contexto = new MeuContexto();

            Categoria cat = contexto.Categorias.Find(id);
            contexto.Categorias.Remove(cat);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
