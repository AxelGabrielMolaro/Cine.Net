using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Entity;
using MVC.Services;
using MVC.DaoImpl;
namespace MVC.ServicesImpl
{
    public class sedeServiceImpl : SedeService
    {
        SedeDaoImpl sedeDao = new SedeDaoImpl();

        //crea una sede, si es null tira error que lo trato en el controlador
        public void crearSede(SEDE sedeAGrabar)
        {
            if (sedeAGrabar == null)
            {
                throw new Exception("Error al grabar sede . Por favor ingrese una sede");
            }
            else
            {
                sedeDao.grabarSedeEnLaBdd(sedeAGrabar);
            }
        }

        //Elimina una sede, si el id es 0 significa que no va a existir, ya que todas arrancan de 1
        public void eliminarSedePorId(int id)
        {
            if (id == 0)
            {
                throw new Exception("Error al borrar sede, esa sede no existe");
            }
            else
            {
                sedeDao.eliminarSedeDeLaBddPorId(id);
            }
        }

        //Trae todas las sedes, si esta vacia tira exepcion , y si no trae el listado
        public List<SEDE> getListadoDeSedes()
        {
            List<SEDE> listado = sedeDao.getListadoDeSedes();
            if (listado == null || listado.ToArray().Length == 0)
            {
                throw new Exception("No hay sedes cargadas");
            }
            else
            {
                return listado;
            }
        }

        //trae una sede por id , si el id es 0 tira error, o si la sede que traigo no existe
        public SEDE getSedePorId(int id)
        {
            SEDE sede = sedeDao.getSedePorId(id);
            if(id == 0)
            {
                throw new Exception("Error al buscar sede. Esa sede no existe");
            }
            if (sede == null)
            {
                throw new Exception("Error al buscar sede. No existe una sede con esa id");
            }
            else
            {
                return sede;
            }

           
        }

        //modifica una sede, si algun campo esta vacio tirra excepcion
        public void modificarSedeorId(int id, string nombre, string direccion, string precioEntradaGeneral)
        {
            try
            {
                sedeDao.modificarSedeDeLaBddPorId(id, nombre, direccion, precioEntradaGeneral);
            }
            catch
            {
                throw new Exception("Error al modificar sede. Por favor no deje campos vacios");
            }
        }
    }
}