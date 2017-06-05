using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Entity;
namespace MVC.Dao
{
    interface PeliculaDao
    {
        /*Listar*/

        List<PELICULA> getListadoDePeliculas();


        /*Agregar*/
        void grabarPeliculaEnLaBaseDeDatos(PELICULA pelicula);
    }
}
