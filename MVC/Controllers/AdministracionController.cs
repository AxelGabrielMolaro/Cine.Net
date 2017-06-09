using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.ServicesImpl;
using MVC.Models;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing;
using MVC.Entity;

namespace MVC.Controllers
{
    public class AdministracionController : Controller
    {
        //todos los services que tienen mi logica
        PeliculaServiceImpl peliculaService = new PeliculaServiceImpl();
        sedeServiceImpl sedeService = new sedeServiceImpl();


        // GET: Administracion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult inicio()
        {
            return View();
        }

        //Muesta en las vista las peliculas
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
                model.listadoDePeliculas = new List<Peliculas>();
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
                return View(model);
            }
            else
            {
                 try
                {
                ViewBag.ErrorPelicula = "";
                Entity.Peliculas peliculaAAgregar = new Entity.Peliculas();



                peliculaAAgregar.Nombre = model.nombrePeliculaModel;
                peliculaAAgregar.Descripcion = model.descripcionPeliculaModel;
                peliculaAAgregar.IdCalificacion = Convert.ToInt32(model.idCalificacionPeliculaModel);
                peliculaAAgregar.Duracion = Convert.ToInt32(model.duracionPeliculaModel);
                peliculaAAgregar.IdGenero =Convert.ToInt32( model.idgeneroPeliculaModel);
                //imagen
                //fecha
              
             
                    peliculaService.grabarUnaPelicula(peliculaAAgregar);
                    return RedirectToAction("peliculas");
                }
                catch (Exception e)
                {
                    ViewBag.ErrorPelicula = e.Message;
                    return View(model);
                }
            }
            
        }

        //sede

        //lista las sedes por request
        public ActionResult sedes()
        {

            if (!ModelState.IsValid)
            {
                return View("agregarSede");
            }
            else
            {
                SedeModelAndView model = new SedeModelAndView();
                try
                {
                    ViewBag.errorSede = "";
                    model.listadoDeSedesModel = sedeService.getListadoDeSedes();
                    return View(model);
                }
                catch (Exception e)
                {
                    ViewBag.errorSede = e.Message;
                    model.listadoDeSedesModel = new List<Sedes>();
                    return View(model);
                }
            }
          
        }

        //Envia al formulario de agregar sede
        //Este formulario lo uso para editar, y para agregar
        [HttpPost]
        public ActionResult agregarSede(SedeModelAndView model)
        {
            if (model.IdSede == 0)
            {
                
                model.nombreSedeModel = "Ingrese nombre";

                return View(new SedeModelAndView());
            }
            else {
                try
                {
                    Sedes sedeAEditar = sedeService.getSedePorId(Convert.ToInt32(model.IdSede));
                    model.nombreSedeModel = sedeAEditar.Nombre;
                    model.direccionSedeModel = sedeAEditar.Direccion;
                    model.precioEntradaGeneralModel = sedeAEditar.PrecioGeneral.ToString();
                }
                catch (Exception e)
                {
                    ViewBag.errorSede = "Error al modificar sede. Error traer sede a modificar";
                    RedirectToAction("sedes");
                }
                return View(model);
            }
            
        }

        //aca si es una sede nueva agrega si no edita , llama a los metodos correspondientes
        //ante la peticion por request
        [HttpPost]
        public ActionResult agregarSedePost(SedeModelAndView model)
        {

            if (!ModelState.IsValid)
            {
                return View("AgregarSede", model);
            }
            else
            {

                if (model.idSedeModel == null || model.idSedeModel == "0")//agrega
                {
                    Sedes sedeAAgregar = new Sedes();
                    sedeAAgregar.Nombre = model.nombreSedeModel;
                    sedeAAgregar.Direccion = model.direccionSedeModel;
                    sedeAAgregar.PrecioGeneral = Convert.ToInt32(model.precioEntradaGeneralModel);
                    try
                    {
                        ViewBag.errorSede = "";
                        sedeService.crearSede(sedeAAgregar);
                    }
                    catch (Exception e)
                    {
                        ViewBag.errorSede = "Error al agregar sede, por favor no lene los campos vacios.";
                        return View("agregarSede", model);

                    }

                    return RedirectToAction("sedes");
                }
                else
                { //Modifica uno ya existente
                    try
                    {
                        ViewBag.errorSede = "";
                        sedeService.modificarSedeorId(Convert.ToInt32(model.idSedeModel), model.nombreSedeModel, model.direccionSedeModel, model.precioEntradaGeneralModel);
                    }
                    catch (Exception e)
                    {
                        ViewBag.errorSede = e.Message;
                        return View("agregarSede", model);
                    }
                    return RedirectToAction("sedes");
                }

            }

        }
        //reservas
        public ActionResult reportes()
        {
            return View();

        }
    }
}