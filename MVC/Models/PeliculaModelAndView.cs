using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Entity;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models
{
    public class PeliculaModelAndView :PELICULA
    {
        public int idPelicula { get; set; }
        public string nombrePelicula { get; set; }
        public string  descripcionPelicula { get; set; }
        public string calificacionPelicula { get; set; }
        public string generoPelicula { get; set; }
        public string imagenPelicula { get; set; }
        public string duracionPelicula { get; set; }

        public byte[] imagenPeliculaBdd { get; set; }

        //para listar las peliculas
        public List<PELICULA> listadoDePeliculas;

        //para recibir File Imagen Del Formulario
        
        public HttpPostedFileBase imagenCargadaPelicula { get; set; }

        public PeliculaModelAndView()
        {
            this.idPelicula = ID;
            this.nombrePelicula = NOMBRE;
            this.descripcionPelicula = DESCRIPCION;
            this.calificacionPelicula = CALIFICACION.ToString();
            this.generoPelicula = GENERO;
            this.imagenPeliculaBdd = IMAGEN;
            this.duracionPelicula = DURACION;
            this.listadoDePeliculas = new List<PELICULA>();


        }
    }
}