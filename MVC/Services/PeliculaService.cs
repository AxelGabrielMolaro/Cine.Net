using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Entity;

namespace MVC.Services
{
    interface PeliculaService
    {

        /*Listar*/

        List<PELICULA> getListadoDePeliculas();


        /*Agregar*/
        void grabarUnaPelicula(PELICULA pelicula);
    }
}
