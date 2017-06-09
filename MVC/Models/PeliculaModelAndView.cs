using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Entity;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models
{
    public class PeliculaModelAndView :Peliculas
    {
        public string idPeliculaModel { get; set; }
        public string nombrePeliculaModel { get; set; }
        public string descripcionPeliculaModel { get; set; }
        public string idCalificacionPeliculaModel { get; set; }
        public string idgeneroPeliculaModel { get; set; }
        public string imagenPeliculaModel { get; set; }
        public string duracionPeliculaModel { get; set; }
        public string fechaDeCargaPeliculaModel { get; set; }


        //public byte[] imagenPeliculaBdd { get; set; }

        //para listar las peliculas
        public List<Peliculas> listadoDePeliculas { get; set; }
      

      
        public PeliculaModelAndView()
        {
            this.idPeliculaModel = IdPelicula.ToString();
            this.nombrePeliculaModel = Nombre;
            this.descripcionPeliculaModel = Descripcion;
            this.idCalificacionPeliculaModel = IdCalificacion.ToString();
            this.idgeneroPeliculaModel = IdGenero.ToString();
            this.imagenPeliculaModel = Imagen;
            this.duracionPeliculaModel = Duracion.ToString();
            this.fechaDeCargaPeliculaModel = FechaCarga.ToString(); 
            this.listadoDePeliculas = new List<Peliculas>();


        }


    }
}