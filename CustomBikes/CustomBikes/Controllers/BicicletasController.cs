using CustomBikes.Models;
using CustomBikes.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}