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
    public class QuadrosController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET: Quadros
        public ActionResult Index()
        {
            // Conecta o banco
            MeuContexto contexto = new MeuContexto();

            List<Quadro> quadros = contexto.Quadros.ToList();
            return View(quadros);
        }


        // GET: Quadros create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quadros create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Quadro quadro)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Quadros.Add(quadro);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quadro);
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
            Quadro qua = contexto.Quadros.Find(id);

            if (qua == null)
            {
                return HttpNotFound();
            }

            return View(qua);

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
            Quadro qua = contexto.Quadros.Find(id);

            if (qua == null)
            {
                return HttpNotFound();
            }

            return View(qua);

        }

        //Edição
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Quadro qua)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(qua).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(qua);
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
            Quadro qua = contexto.Quadros.Find(id);

            if (qua == null)
            {
                return HttpNotFound();
            }

            return View(qua);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            MeuContexto contexto = new MeuContexto();

            Quadro qua = contexto.Quadros.Find(id);
            contexto.Quadros.Remove(qua);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
