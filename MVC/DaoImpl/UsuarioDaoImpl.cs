using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Dao;
using MVC.Entity;
using MVC.Manager;

namespace MVC.DaoImpl
{
    public class UsuarioDaoImpl : UsuarioDao
    {

        RepositorioManager repositorioManager = new RepositorioManager();
   

        //Le pasas un id y te devuelve un usuario, el primero que encuentre con ese id
        public USUARIO buscarUnUsuarioPorId(int id)
        {
           var usuarioBuscado = repositorioManager.ctx.USUARIO.LastOrDefault(o => o.ID == id);
            if (usuarioBuscado != null)
            {
                return usuarioBuscado;
            }
            else {
                   
                   throw new Exception ("Error , el usuario que quieres buscar por id no existe");
            }
        }

        //Le pasas un nombre y te devuelve el primer usuario con ese nombre
        public USUARIO buscarUnUsuarioPorNombre(string nombreUsuario)
        {
           
            var usuarioBuscado = repositorioManager.ctx.USUARIO.OrderByDescending(o => o.NOMBRE == nombreUsuario).FirstOrDefault();

           // var usuarioBuscado = (from u in repositorioManager.ctx.USUARIO select u).FirstOrDefault();

            if(usuarioBuscado != null)
            {
                return usuarioBuscado;
            }
            else {
                throw new Exception("Error, el usuario que quieres buscar por nombre no existe");
            }

        }

    }
}