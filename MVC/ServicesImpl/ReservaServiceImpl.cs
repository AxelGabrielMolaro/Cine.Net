using MVC.DaoImpl;
using MVC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ServicesImpl
{
    /// <summary>
    /// Agregar una reserva y valida los datos, tira excepciones
    /// </summary>
    public class ReservaServiceImpl
    {
        ReservaDaoImpl reservaDao = new ReservaDaoImpl();

        public void agregarReserva(Reservas reserva)
        {
            //validar
            reservaDao.agregarReserva(reserva);
        }
    }
}