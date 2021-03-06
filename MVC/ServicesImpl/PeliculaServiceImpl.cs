﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Entity;
using MVC.DaoImpl;
using MVC.Manager;

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





        /// <summary>
        /// Trar un listado de peliculas actuales y con un mes de anticipacion
        /// </summary>
        public List<Peliculas> getListadoDePeliculasHome()
        {
            List<Peliculas> listadoDePeliculasAMostrar = new List<Peliculas>();
            List<Carteleras> listadoDeCarteleras = getListadoDeCartelerasHome(); //ver
            foreach (Carteleras cartelera in listadoDeCarteleras)
            {
                listadoDePeliculasAMostrar.Add(peliculaDao.getPeliculaPorId(cartelera.IdPelicula));
            }
            return listadoDePeliculasAMostrar;
        }


        //pasar a cartelera
        /// <summary>
        /// Trar un listado de carteleras actuales y con un mes de anticipacion
        /// </summary>
        public List<Carteleras> getListadoDeCartelerasHome()
        {
            
            CarteleraDaoImpl carteleraDao = new CarteleraDaoImpl();
            List<Carteleras> listadoDeCarteleras = carteleraDao.getListadoDeCarteleras();
            List<Carteleras> listadoDeCartelerasAMostrar = new List<Carteleras>();
            foreach (Carteleras cartelera in listadoDeCarteleras)
            {
                int mesDeHoy = DateTime.Now.Month;
                int mesDeCartelera = cartelera.FechaInicio.Month;
                int diferenciaFechas = mesDeCartelera -  mesDeHoy ;
                if (cartelera.IdPelicula != 0 && diferenciaFechas <= 1)
                {
                    if(cartelera!=null)
                    {
                        listadoDeCartelerasAMostrar.Add(cartelera);
                    }                    
                }
            }

            return listadoDeCartelerasAMostrar;

        }


        //camviar dps 
        public Carteleras getCarteleraPorId(int id)
        {
            RepositorioManager repositorioManager = new RepositorioManager();
            Carteleras carteleraBuscada = repositorioManager.ctx.Carteleras.OrderByDescending(o => o.IdCartelera == id).FirstOrDefault();
            return carteleraBuscada;
        }
    }
}