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
                  var imagen = model.listadoDePeliculas[0].IMAGEN;
              
               
                //no anada lo de la imagen

                
                ViewBag.imagenp = imagen;
                return View(model);
            }
            catch (Exception e)
            {
                ViewBag.ErrorPelicula = e.Message;
                model.listadoDePeliculas = new List<PELICULA>();
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
                // try
                //{
                ViewBag.ErrorPelicula = "";
                Entity.PELICULA peliculaAAgregar = new Entity.PELICULA();



                peliculaAAgregar.NOMBRE = model.nombrePelicula;
                peliculaAAgregar.DESCRIPCION = model.descripcionPelicula;
                peliculaAAgregar.CALIFICACION = Int32.Parse(model.calificacionPelicula);
                peliculaAAgregar.DURACION = model.descripcionPelicula;
                peliculaAAgregar.GENERO = model.generoPelicula;

                //Imagen
                //peliculaAAgregar.IMAGEN = new byte[imagen.ContentLength];
                peliculaAAgregar.IMAGEN = new byte[model.imagenPelicula.Length];
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
                    model.listadoDeSedes = sedeService.getListadoDeSedes();
                    return View(model);
                }
                catch (Exception e)
                {
                    ViewBag.errorSede = e.Message;
                    model.listadoDeSedes = new List<SEDE>();
                    return View(model);
                }
            }
          
        }

        //Envia al formulario de agregar sede
        //Este formulario lo uso para editar, y para agregar
        [HttpPost]
        public ActionResult agregarSede(SedeModelAndView model)
        {
            if (model.idSede == "0")
            {
                
                model.nombreSede = "Ingrese nombre";

                return View(new SedeModelAndView());
            }
            else {
                try
                {
                    SEDE sedeAEditar = sedeService.getSedePorId(Convert.ToInt32(model.idSede));
                    model.nombreSede = sedeAEditar.NOMBRE;
                    model.direccionSede = sedeAEditar.DIRECCION;
                    model.precioEntradaGeneral = sedeAEditar.PRECIO_ENTRADA_GENERAL.ToString();
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

                if (model.idSede == null || model.idSede == "0")//agrega
                {
                    SEDE sedeAAgregar = new SEDE();
                    sedeAAgregar.NOMBRE = model.nombreSede;
                    sedeAAgregar.DIRECCION = model.direccionSede;
                    sedeAAgregar.PRECIO_ENTRADA_GENERAL = Convert.ToInt32(model.precioEntradaGeneral);
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
                        sedeService.modificarSedeorId(Convert.ToInt32(model.idSede), model.nombreSede, model.direccionSede, model.precioEntradaGeneral);
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