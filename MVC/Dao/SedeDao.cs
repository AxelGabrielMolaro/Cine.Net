using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Entity;
namespace MVC.Dao
{
    interface SedeDao
    {
        List<SEDE> getListadoDeSedes();

        SEDE getSedePorId(int id);

        void modificarSedeDeLaBddPorId(int id,String nombre, String direccion, String precioEntradaGeneral);

        void eliminarSedeDeLaBddPorId(int id);

        void grabarSedeEnLaBdd(SEDE sedeAGrabar);



    }
}
