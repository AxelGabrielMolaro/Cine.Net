﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.ServicesImpl;
using MVC.Models;

namespace MVC.Controllers
{
    public class AdministracionController : Controller
    {
        PeliculaServiceImpl peliculaService = new PeliculaServiceImpl();

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
            PeliculaModelAndView model = new PeliculaModelAndView();
            try
            {
                ViewBag.ErrorPelicula = "";
                
                model.listadoDePeliculas = peliculaService.getListadoDePeliculas();
                return View(model);
            }
            catch (Exception e)
            {
                ViewBag.ErrorPelicula = e.Message;
                model.listadoDePeliculas = peliculaService.getListadoDePeliculas();
                return View(model);

            }
        

        }

        //El el formulario vacio para agregar la pelicula
        public ActionResult agregarPelicula()
        {
            PeliculaModelAndView model = new PeliculaModelAndView();
            return View(model);
        }
        [HttpPost]
        public ActionResult agregarPelicula(PeliculaModelAndView model)
        {
            if (!ModelState.IsValid)
            {
                return View( model);
            }
            else
            {
               // try
                //{
                    ViewBag.ErrorPelicula = "";
                    Entity.PELICULA peliculaAAgregar = new Entity.PELICULA();

                    peliculaAAgregar.NOMBRE = model.nombrePelicula;
                    peliculaAAgregar.DESCRIPCION = model.descripcionPelicula;
                    peliculaAAgregar.CALIFICACION = Int32.Parse(model.calificacionPelicula);
                    peliculaAAgregar.DURACION = model.descripcionPelicula;
                    peliculaAAgregar.GENERO = model.generoPelicula;
                    peliculaAAgregar.IMAGEN = Convert.FromBase64String(model.imagenPelicula);
                    peliculaService.grabarUnaPelicula(peliculaAAgregar);
                    return RedirectToAction("peliculas");
                /*}
                catch (Exception e)
                {
                    ViewBag.ErrorPelicula = e.Message;
                    return View(model);
                }*/
            }
            
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