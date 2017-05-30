using MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AdministracionController : Controller
    {
        // GET: Administracion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult inicio()
        {
            return View();
        }

        /* 
         * 5.5 Gestión de Películas (/administracion/peliculas) (*) 
         * 
         * Esta opción permitirá la carga de las películas que serán proyectadas dentro de las salas de 
         * cine. 
         * 
         * Se deberá visualizar el listado de todas las películas registradas en el sistema. 
         * 
         * La vista tendrá un listado de todas las películas y un botón “Nuevo” para dar de alta nuevas 
         * películas. Desde el listado el usuario podrá seleccionar la película que desea modificar. 
         * 
         * Para el caso de una nueva película, se deberán ingresar los siguientes datos: 
         * 
         * - nombre. 
         * - descripción. 
         * - calificación (ATP, mayores de 13,mayores de 13 con reservas, mayores de 16, mayores 
         * de 16 con reserva) 
         * - género (terror, thriller, acción, comedia, comedia romántica, etc.) 
         * - imagen. 
         * - duración. 
         * 
         * Todos los datos son obligatorios. Para los datos de calificación y género, serán provistos dentro 
         * del modelo de datos. Los mismos deberán ser visualizados en listados seleccionables por el 
         * usuario. 
         * 
         * Las películas no se podrán eliminar. 
         * (*) En caso de no estar logueado, debe redirigirse a /home/login y luego de que el usuario          * ingrese se lo debe auto-redirigir a la página que deseaba ingresar.
         */
        public ActionResult peliculas()
        {
            TPEntities ctx = new TPEntities();
            var peliculas = (from p in ctx.Peliculas
                         select p).ToList();
            if (peliculas.Count() == 0)
            {
                ViewBag.NoHayPeliculas = "No hay películas registradas";
            }
            return View(peliculas);
        }

        public ActionResult agregarPelicula()
        {
            return View();
        }

        [HttpPost]
        public ActionResult agregarPelicula(Peliculas pelicula)
        {
            if (ModelState.IsValid)
            {
                Peliculas p = new Peliculas();
                p.Nombre = pelicula.Nombre;
                p.Descripcion = pelicula.Descripcion;
                p.IdCalificacion = pelicula.IdCalificacion;
                p.IdGenero = pelicula.IdGenero;
                p.Imagen = pelicula.Imagen;
                p.Duracion = pelicula.Duracion;
                p.FechaCarga = DateTime.Now;
                TPEntities ctx = new TPEntities();
                ctx.Peliculas.Add(p);
                ctx.SaveChanges();
                TempData["PeliculaAgregada"] = "¡La película " + p.Nombre + " se agregó correctamente!";
                return RedirectToAction("peliculas");
            }
            return View();
        }

        public ActionResult modificarPelicula(int id)
        {
            var ctx = new TPEntities();
            Peliculas pelicula = ctx.Peliculas.FirstOrDefault(p => p.IdPelicula == id);
            return View(pelicula);
        }

        [HttpPost]
        public ActionResult modificarPelicula(Peliculas pelicula)
        {
            if (ModelState.IsValid)
            {
                var ctx = new TPEntities();
                Peliculas peli = ctx.Peliculas.FirstOrDefault(p => p.IdPelicula == pelicula.IdPelicula);
                if (peli != null)
                {
                    peli.Nombre = pelicula.Nombre;
                    peli.Descripcion = pelicula.Descripcion;
                    peli.IdCalificacion = pelicula.IdCalificacion;
                    peli.IdGenero = pelicula.IdGenero;
                    peli.Imagen = pelicula.Imagen;
                    peli.Duracion = pelicula.Duracion;
                    ctx.SaveChanges();
                    TempData["PeliculaModificada"] = "¡La película " + peli.Nombre + " se modificó correctamente!";
                    return RedirectToAction("peliculas");
                }
            }
            ModelState.AddModelError("IdPelicula", "La película no existe");
            return View(pelicula);
        }

        /* 
         * 5.6 Gestión de Sedes (/adiministracion/sedes) (*) 
         * 
         * El usuario podrá cargar las sedes que el complejo tiene disponibles. Adicionalmente podrá 
         * modificar los existentes. 
         * 
         * Se deberá visualizar el listado de todas las sedes registradas en el sistema. 
         * 
         * La vista tendrá un listado de todas las sedes y un botón “Nuevo” para dar de alta nuevas sedes. 
         * Desde el listado el usuario podrá seleccionar la sede que desea modificar. 
         * 
         * Para el caso de una nueva sede, se deberán ingresar los siguientes datos: 
         * 
         * - Nombre. 
         * - Dirección 
         * - Precio de entrada general.          *          * Todos los datos son obligatorios. 
         * 
         * Las sedes no se podrán eliminar. 
         * (*) En caso de no estar logueado, debe redirigirse a /home/login y luego de que el usuario 
         * ingrese se lo debe auto-redirigir a la página que deseaba ingresar.
         */
        public ActionResult sedes()
        {
            TPEntities ctx = new TPEntities();
            var sedes = (from s in ctx.Sedes
                         select s).ToList(); 
            if (sedes.Count() == 0)
            {
                ViewBag.NoHaySedes = "No hay sedes registradas";
            }
            return View(sedes);
        }

        public ActionResult agregarSede()
        {
            return View();
        }

        [HttpPost]
        public ActionResult agregarSede(Sedes sede)
        {
            if (ModelState.IsValid)
            {
                Sedes s = new Sedes();
                s.Nombre = sede.Nombre;
                s.Direccion = sede.Direccion;
                s.PrecioGeneral = sede.PrecioGeneral;
                TPEntities ctx = new TPEntities();
                ctx.Sedes.Add(s);
                ctx.SaveChanges();
                TempData["SedeAgregada"] = "¡La sede " + s.Nombre + " se agregó correctamente!";
                return RedirectToAction("sedes"); 
            }
            return View();
        }

        public ActionResult modificarSede(int id)
        {
            var ctx = new TPEntities();
            Sedes sede = ctx.Sedes.FirstOrDefault(s => s.IdSede == id);
            return View(sede);
        }

        [HttpPost]
        public ActionResult modificarSede(Sedes sede)
        {
            if (ModelState.IsValid)
            {
                var ctx = new TPEntities();
                Sedes sd = ctx.Sedes.FirstOrDefault(s => s.IdSede == sede.IdSede);
                if (sd != null)
                {
                    sd.Nombre = sede.Nombre;
                    sd.Direccion = sede.Direccion;
                    sd.PrecioGeneral = sede.PrecioGeneral;
                    ctx.SaveChanges();
                    TempData["SedeModificada"] = "¡La sede " + sd.Nombre + " se modificó correctamente!";
                    return RedirectToAction("sedes");
                }
            }
            ModelState.AddModelError("IdSede", "La sede no existe");
            return View(sede);
        } 

        //reservas
        public ActionResult reportes()
        {
            return View();

        }
    }
}