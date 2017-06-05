using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Entity;

namespace MVC.Dao
{
    interface UsuarioDao
    {

       /*Para el login*/

        USUARIO buscarUnUsuarioPorId(int id);

        USUARIO buscarUnUsuarioPorNombre(string nombre);



        
    }
}
