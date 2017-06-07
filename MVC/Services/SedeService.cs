using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Entity;

namespace MVC.Services
{
    interface SedeService
    {
        List<SEDE> getListadoDeSedes();

        SEDE getSedePorId(int id);

        void modificarSedeorId(int id, String nombre, String direccion, String precioEntradaGeneral);

        void eliminarSedePorId(int id);

        void crearSede(SEDE sedeAGrabar);

    }
}
