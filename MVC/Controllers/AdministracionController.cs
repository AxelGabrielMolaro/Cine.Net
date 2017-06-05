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
            return View();
        }

        public ActionResult agregarSede()
        {
            return View();
        }
        //reservas
        public ActionResult reportes()
        {
            return View();

        }
    }
}