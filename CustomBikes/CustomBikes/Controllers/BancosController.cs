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
    public class BancosController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET: Bancos
        public ActionResult Index()
        {
            // Conecta o banco
            MeuContexto contexto = new MeuContexto();

            List<Banco> bancos = contexto.Bancos.ToList();
            return View(bancos);
        }


        // GET: Bancos create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bancos create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Banco banco)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Bancos.Add(banco);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banco);
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
            Banco ban = contexto.Bancos.Find(id);

            if (ban == null)
            {
                return HttpNotFound();
            }

            return View(ban);

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
            Banco ban = contexto.Bancos.Find(id);

            if (ban == null)
            {
                return HttpNotFound();
            }

            return View(ban);

        }

        //Edição
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Banco ban)
        {
            if (ModelState.IsValid)
            {
                MeuContexto contexto = new MeuContexto();
                contexto.Entry(ban).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(ban);
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
            Banco ban = contexto.Bancos.Find(id);

            if (ban == null)
            {
                return HttpNotFound();
            }

            return View(ban);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            MeuContexto contexto = new MeuContexto();

            Banco ban = contexto.Bancos.Find(id);
            contexto.Bancos.Remove(ban);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
