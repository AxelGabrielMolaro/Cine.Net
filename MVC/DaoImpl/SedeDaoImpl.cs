using MVC.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Entity;
using MVC.Manager;
namespace MVC.DaoImpl
{
    public class SedeDaoImpl : SedeDao
    {
        RepositorioManager repositorioManager = new RepositorioManager();


        //Busca una sede por id y la elimina
        public void eliminarSedeDeLaBddPorId(int id)
        {
            SEDE sedeABorrar = getSedePorId(id);
            repositorioManager.ctx.SEDE.Remove(sedeABorrar);
            repositorioManager.ctx.SaveChanges();
        }
        
        //Trae todas las sedes
        public List<SEDE> getListadoDeSedes()
        {
            var listadoDESedesBdd = from sede in repositorioManager.ctx.SEDE select sede;
            List<SEDE> listado = listadoDESedesBdd.ToList();
            return listado;
        }

        //Obtiene un sede por id
        public SEDE getSedePorId(int id)
        {
            SEDE sedeBuscada = repositorioManager.ctx.SEDE.OrderByDescending(o => o.ID == id).FirstOrDefault();
            return sedeBuscada;
        }

        //Graba una sede en la bdd, si la id es la misma la pisa
        public void grabarSedeEnLaBdd(SEDE sedeAGrabar)
        {
            repositorioManager.ctx.SEDE.Add(sedeAGrabar);
            repositorioManager.ctx.SaveChanges();
        }

        //si ningun campo esta vacio modifica un usuario, si no tira excepcion
        public void modificarSedeDeLaBddPorId(int id, string nombre, string direccion, string precioEntradaGeneral)
        {
            if (id == 0)
            {
                throw new Exception("Error en al id , al consultar sede en la base de datos");
            }
            else
            {
                SEDE sede = getSedePorId(id);
               
                if (nombre != null)
                {
                    sede.NOMBRE = nombre;
                }
                else
                {
                    throw new Exception("Error al modificar usuario en la base de datos, hay campos vacios");
                }

                if (direccion != null )
                {
                    sede.DIRECCION = direccion;
                }
                else
                {
                    throw new Exception("Error al modificar usuario en la base de datos, hay campos vacios");
                }

                if (precioEntradaGeneral != null )
                {
                    sede.PRECIO_ENTRADA_GENERAL = Convert.ToInt32(precioEntradaGeneral);
                }
                else
                {
                    throw new Exception("Error al modificar usuario en la base de datos, hay campos vacios");
                }



                repositorioManager.ctx.SaveChanges();
               
       
            }
        }
    }
}