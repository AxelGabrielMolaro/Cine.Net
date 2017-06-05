using MVC.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Entity;
using MVC.Manager;
namespace MVC.DaoImpl
{
    public class PeliculaDaoImpl : PeliculaDao
    {
        RepositorioManager repositorioManager = new RepositorioManager();

        //Trae todas las peliculas de la base de datos
        public List<PELICULA> getListadoDePeliculas()
        {
            var listadoDePeliculas = (from pelicula in repositorioManager.ctx.PELICULA select pelicula);
            List<PELICULA> listadoDePeliculasADevolver = listadoDePeliculas.ToList();

            if (listadoDePeliculas != null)
            {
                return listadoDePeliculasADevolver;
            }
            else 
            {
                throw new Exception("Error al traer la lista de peliculas de la base de datos");
            }

        }

        //guarda una pelicula en al base de datos
        public void grabarPeliculaEnLaBaseDeDatos(PELICULA pelicula)
        {
            
            repositorioManager.ctx.PELICULA.Add(pelicula);
            repositorioManager.ctx.SaveChanges();
        }
    }
}