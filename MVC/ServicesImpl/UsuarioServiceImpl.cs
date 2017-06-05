using MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Entity;
using MVC.DaoImpl;

namespace MVC.ServicesImpl
{
    public class UsuarioServiceImpl : UsuarioService
    {

        UsuarioDaoImpl usuarioDao = new UsuarioDaoImpl();
            
        //Le pasas un nombre , lo va a buscar en la bdd ,y va a ver si coinciden las contraseñas
        //Si counciden devuelve un usuario , si no counciden tira una excepcion
        public USUARIO login(string nombre, string contraseña)
        {
            USUARIO usuarioBuscado = usuarioDao.buscarUnUsuarioPorNombre(nombre);
            try
            {
                if (usuarioBuscado.NOMBRE == nombre && usuarioBuscado.CONTRASEÑA == contraseña)
                {
                    return usuarioBuscado;
                }
                else {
                    throw new Exception("Error al ingresar, verifique su nombre y su contraseña");
                }
               
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}