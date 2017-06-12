using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.Entity;
using MVC.ServicesImpl;

namespace MVC.Controllers
{
    public class PeliculasController : Controller
    {
        sedeServiceImpl sedeService = new sedeServiceImpl();
        VersionServiceImpl versionService = new VersionServiceImpl();
        // GET: Peliculas
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult reserva(ReservaModelAndView model)
        {
            model.listadoDeSedesReservaModel = sedeService.getListadoDeSedes();
            model.listadoDeVersionesReservaModel = versionService.getListadoDeVersiones();
            return View(model);
        }
        
        [HttpPost]
        public ActionResult reserva2(ReservaModelAndView model)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("reserva");
                return View(model);
            }
            else
            {/*
                Reservas nuevaReserva = new Reservas() {
                    CantidadEntradas = Convert.ToInt32(model.cantidadDeEntradasReservaModel),
                    Email = model.mailReservaModel,
                    FechaCarga = DateTime.Now, //no se si este sera el dia
                    IdPelicula = Convert.ToInt32(model.idPeliculaReservaModel),
                    IdSede = Convert.ToInt32(model.IdSede)
                    

                };*/
                return View(model);
            }
            
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