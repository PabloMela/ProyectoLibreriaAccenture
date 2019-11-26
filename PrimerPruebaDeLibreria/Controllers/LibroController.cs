using PrimerPruebaDeLibreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimerPruebaDeLibreria.Controllers
{
    public class LibroController : Controller
    {
        Biblioteca_LeopoldoMarechalEntities2 db = new Biblioteca_LeopoldoMarechalEntities2();
        public ActionResult Mostrar()
        {
            List<Libros> libros = db.Libros.OrderBy(g => g.Titulo).ToList();
            return View(libros);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        public ActionResult VerLibro(int id)
        {
            Libros libro = db.Libros.Find(id);
            return View(libro);
        }

        [HttpPost]
        public ActionResult Agregar(Libros nuevo)
        {
            List<Autores> autores = db.Autores.ToList();
            List<Editoriales> editoriales = db.Editoriales.ToList();
            List<Generos> generos = db.Generos.ToList();
            List<Libros> libros = db.Libros.ToList();

            Autores autorAux = autores.Find(g => g.Nombre == nuevo.Autor);
            if(autorAux == null)
            {
                return View("AutorInexistente");
            }

            nuevo.IdAutor = autorAux.Id;

            if(nuevo.Autor2 != null)
            {
                Autores autorAux2 = autores.Find(g => g.Nombre == nuevo.Autor2);
                if(autorAux2 == null)
                {
                    return RedirectToAction("CampoInvalido");
                }
                nuevo.IdAutor3 = autorAux2.Id;
            }

            if (nuevo.Autor3 != null)
            {
                Autores autorAux2 = autores.Find(g => g.Nombre == nuevo.Autor3);
                if (autorAux2 == null)
                {
                    return RedirectToAction("CampoInvalido");
                }
                nuevo.IdAutor3 = autorAux2.Id;
            }

            if (nuevo.Editorial != null)
            {
                Editoriales editorialAux = editoriales.Find(g => g.Nombre == nuevo.Editorial);
                if (editorialAux == null)
                {
                    return RedirectToAction("CampoInvalido");
                }
                nuevo.IdEditorial = editorialAux.Id;
            }

            if(nuevo.Descripcion == null)
            {
                return RedirectToAction("CampoInvalido");
            }

            if(nuevo.ISBN == null)
            {
                return RedirectToAction("CampoInvalido");
            }

            Generos generoAux = generos.Find(g => g.Nombre == nuevo.Genero);
            if(generoAux == null)
            {
                return RedirectToAction("CampoInvalido");
            }
            nuevo.IdGenero = generoAux.Id;

            if (nuevo.SubGenero != null)
            {
                Generos generoAux2 = generos.Find(g => g.Nombre == nuevo.SubGenero);
                if (generoAux2 == null)
                {
                    return RedirectToAction("CampoInvalido");
                }
                nuevo.IdSubGenero = generoAux2.Id;
            }

            Libros libroAux = libros.Find(g => g.Titulo == nuevo.Titulo);
            if(libroAux != null)
            {
                return View("LibroExistente");
            }

            if (nuevo.SubGenero2 != null)
            {
                Generos generoAux2 = generos.Find(g => g.Nombre == nuevo.SubGenero2);
                if (generoAux2 == null)
                {
                    return RedirectToAction("CampoInvalido");
                }
                nuevo.IdSubGenero2 = generoAux2.Id;
            }

            Random r = new Random();

            if(nuevo.FechaPublicacion == null)
            {
                return RedirectToAction("CampoInvalido");
            }
            
            nuevo.Stock = r.Next(0, 25);
            nuevo.Precio = r.Next(0, 3000);

            db.Libros.Add(nuevo);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }

        public ActionResult Modificar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Modificar(Libros nuevo)
        {
            List<Autores> autores = db.Autores.ToList();
            List<Editoriales> editoriales = db.Editoriales.ToList();
            List<Generos> generos = db.Generos.ToList();
            List<Libros> libros = db.Libros.ToList();
            Libros libroAux = libros.Find(g => g.ISBN == nuevo.ISBN);
            if(libroAux == null)
            {
                return View("LibroNoExistente");
            }

            if(nuevo.Autor !=null)
            {
                Autores autorAux = autores.Find(g => g.Nombre == nuevo.Autor);
                if(autorAux == null)
                {
                    return View("CampoInvalido");
                }
                nuevo.IdAutor = autorAux.Id;
                libroAux.Autor = nuevo.Autor;
            }

            if (nuevo.Autor2 != null)
            {
                Autores autorAux = autores.Find(g => g.Nombre == nuevo.Autor2);
                if (autorAux == null)
                {
                    return View("CampoInvalido");
                }
                nuevo.IdAutor = autorAux.Id;
                libroAux.Autor = nuevo.Autor2;
            }

            if (nuevo.Autor3 != null)
            {
                Autores autorAux = autores.Find(g => g.Nombre == nuevo.Autor3);
                if (autorAux == null)
                {
                    return View("CampoInvalido");
                }
                nuevo.IdAutor = autorAux.Id;
                libroAux.Autor = nuevo.Autor3;
            }

            if (nuevo.Descripcion != null)
            {
                libroAux.Descripcion = nuevo.Descripcion;
            }

            if (nuevo.Editorial != null)
            {
                Editoriales editorialAux = editoriales.Find(g => g.Nombre == nuevo.Editorial);
                if (editorialAux == null)
                {
                    return View("CampoInvalido");
                }
                nuevo.IdEditorial = editorialAux.Id;
                libroAux.Editorial = nuevo.Editorial;
            }

            if(nuevo.Titulo != null)
            {
                libroAux.Titulo = nuevo.Titulo;
            }

            if (nuevo.FechaPublicacion != null)
            {
                libroAux.FechaPublicacion = nuevo.FechaPublicacion;
            }

            if (nuevo.Genero != null)
            {
                Generos generoAux = generos.Find(g => g.Nombre == nuevo.Genero);
                if (generoAux == null)
                {
                    return View("CampoInvalido");
                }
                nuevo.IdGenero = generoAux.Id;
                libroAux.Genero = nuevo.Genero;
            }

            if (nuevo.SubGenero != null)
            {
                Generos generoAux = generos.Find(g => g.Nombre == nuevo.SubGenero);
                if (generoAux == null)
                {
                    return View("CampoInvalido");
                }
                nuevo.IdSubGenero = generoAux.Id;
                libroAux.SubGenero = nuevo.SubGenero;
            }

            if (nuevo.SubGenero2 != null)
            {
                Generos generoAux = generos.Find(g => g.Nombre == nuevo.SubGenero2);
                if (generoAux == null)
                {
                    return View("CampoInvalido");
                }
                nuevo.IdSubGenero2 = generoAux.Id;
                libroAux.SubGenero2 = nuevo.SubGenero2;
            }

            libros.Add(libroAux);
            db.SaveChanges();

            return RedirectToAction("Mostrar");
        }

        public ActionResult LibroNoModificable()
        {
            return View();
        }
        public ActionResult CampoInvalido()
        {
            return View();
        }

        public ActionResult ModificarLibro(int id)
        {
            Libros libro = db.Libros.Find(id);
            return View(libro);
        }

        public ActionResult EliminarLibro(int id)
        {
            Libros libro = db.Libros.Find(id);
            db.Libros.Remove(libro);
            db.SaveChanges();
            return RedirectToAction("Mostrar");
        }

        public ActionResult Buscar()
        {

            return View();
        }
    }
}