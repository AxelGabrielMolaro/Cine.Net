using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class PeliculasController : Controller
    {
        // GET: Peliculas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult reserva()
        {
            return View(new ModelAndViewReserva());
        }
        
        
        public ActionResult reserva2(ModelAndViewReserva model)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("reserva");
            }
            return View();
        }

       [HttpPost]
        public ActionResult finalizarReserva(ModelAndViewReservaFinal model)
        {
            if (!ModelState.IsValid)
            {
                
                return RedirectToAction("reserva2",model);

            }

            return Redirect("/Home/inicio");

        }
    }
}