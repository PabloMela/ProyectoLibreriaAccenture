using PrimerPruebaDeLibreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//VIDEO DOWNLOAD HELPER

namespace PrimerPruebaDeLibreria.Controllers
{
    public class AutorController : Controller
    {
        Biblioteca_LeopoldoMarechalEntities2 db = new Biblioteca_LeopoldoMarechalEntities2();

        public ActionResult Mostrar()
        {
            List<Autores> autores = db.Autores.OrderBy(g => g.Nombre).ToList();
            return View(autores);
        }

        public ActionResult Eliminar(int id)
        {
            Autores autor = db.Autores.Find(id);
            db.Autores.Remove(autor);
            db.SaveChanges();
            return RedirectToAction("Mostrar");
        }

        //MUESTRA UN AUTOR ESPECIFICO
        public ActionResult VerAutor(int id)
        {
            Autores autor = db.Autores.Find(id);
            ViewBag.Nombre = autor.Nombre;
            return View(autor);
        }

        public ActionResult ModificarAutor(int id)
        {
            Autores autor = db.Autores.Find(id);
            ViewBag.Nombre = autor.Nombre;
            return View(autor);
        }

        [HttpPost]
        public ActionResult ModificarAutor(Autores autor)
        {

            ViewBag.Nombre = autor.Nombre;
            return View(autor);
        }
    }
}