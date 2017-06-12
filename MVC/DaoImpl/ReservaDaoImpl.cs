using MVC.Entity;
using MVC.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.DaoImpl
{
    
    public class ReservaDaoImpl
    {
        RepositorioManager repositorioManaer = new RepositorioManager();
        /// <summary>
        /// Agrega un reserva en la base de datos
        /// </summary>
        /// <param name="reserva"></param>
        public void agregarReserva(Reservas reserva)
        {
            repositorioManaer.ctx.Reservas.Add(reserva);
            repositorioManaer.ctx.SaveChanges();
            
        }

        /// <summary>
        /// Busca una reserva por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Reservas getReservaPorId(int id) {

            return null;
        }
    }
}