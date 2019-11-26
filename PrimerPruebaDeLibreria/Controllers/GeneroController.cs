using PrimerPruebaDeLibreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimerPruebaDeLibreria.Controllers
{
    public class GeneroController : Controller
    {
        Biblioteca_LeopoldoMarechalEntities2 db = new Biblioteca_LeopoldoMarechalEntities2();

        public ActionResult Mostrar()
        {
            List<Generos> generos = db.Generos.ToList();
            return View(generos);
        }
    }
}