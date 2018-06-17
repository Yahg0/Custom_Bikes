using CustomBikes.Models;
using CustomBikes.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CustomBikes.Controllers
{
    public class BicicletasController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET: Bicicletas
        public ActionResult Index()
        {
            // Conecta o banco
            MeuContexto contexto = new MeuContexto();

            List<Bicicleta> bicicletas = contexto.Bicicletas.ToList();
            return View(bicicletas);
        }


        // GET: Bicicletas create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bicicletas create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bicicleta bicicleta)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Bicicletas.Add(bicicleta);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bicicleta);
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
            Bicicleta bici = contexto.Bicicletas.Find(id);

            if (bici == null)
            {
                return HttpNotFound();
            }

            return View(bici);

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
            Bicicleta bici = contexto.Bicicletas.Find(id);

            if (bici == null)
            {
                return HttpNotFound();
            }

            return View(bici);

        }

        //Edição
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bicicleta bici)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(bici).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(bici);
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
            Bicicleta bici = contexto.Bicicletas.Find(id);

            if (bici == null)
            {
                return HttpNotFound();
            }

            return View(bici);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            MeuContexto contexto = new MeuContexto();

            Bicicleta bici = contexto.Bicicletas.Find(id);
            contexto.Bicicletas.Remove(bici);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}