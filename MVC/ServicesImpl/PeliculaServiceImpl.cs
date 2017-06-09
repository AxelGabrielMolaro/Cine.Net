
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Entity;
using MVC.DaoImpl;

namespace MVC.ServicesImpl
{
    
    
    public class PeliculaServiceImpl 
    {
        PeliculaDaoImpl peliculaDao = new PeliculaDaoImpl();

        //Si hay un error en la consulta de la bdd devuelve una lista vacia y manda el msj de error
        //Si no hay peliculas cargadas tambien se lanza una excepción
        //Si no hay errores, manda el listado de películas
        public List<Peliculas> getListadoDePeliculas()
        {
            try
            {
                List<Peliculas> listadoDePeliculas = peliculaDao.getListadoDePeliculas();

                if (listadoDePeliculas == null || listadoDePeliculas.ToArray().Length == 0)
                {
                    throw new Exception("No hay ninguna película cargada");

                }
                else
                {
                    return listadoDePeliculas;
                }

            } catch (Exception e){

                //Mostrar exepcion 
                throw new Exception("No hay ninguna pelicula cargada ");
                
                
              
            }
            
        }

        //si es null lanza excepcion
        //Si es correcta se graba la pelicula en la bdd
        public void grabarUnaPelicula(Peliculas pelicula)
        {
            if (pelicula != null)
            {
                peliculaDao.grabarPeliculaEnLaBaseDeDatos(pelicula);
            }
            else
            {
                throw new  Exception("Ingrese una película antes de guardarla");
            }
        }
    }
}