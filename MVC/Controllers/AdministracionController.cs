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
                TempData["SedeAgregada"] = "¡La sede se agregó correctamente!";
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