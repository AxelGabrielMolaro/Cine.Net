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
        //peeliculas
        public ActionResult peliculas()
        {
            return View();
        }

        public ActionResult agregarPelicula()
        {
            return View();
        }
        //sede
        public ActionResult sedes()
        {
            TPEntities ctx = new TPEntities();
            var sedes = (from s in ctx.Sedes
                         select s).ToList();
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
                return RedirectToAction("sedes");
            }
            return View();
        }
        //reservas
        public ActionResult reportes()
        {
            return View();

        }
    }
}