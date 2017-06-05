using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Entity;
namespace MVC.Manager
{

    /*
     * Esta clase lo que hace es simplificar el acceso a las clases de la base de datos generadas
     */
    public class RepositorioManager
    {
        public CARTELERA carteleraEntity  { get; set; }
        public SEDE sedeEntity { get; set; }
        public RESERVA reservaEntity { get; set; }
        public REPORTES_DE_RESERVAS reporteEntity { get; set; }
        public PELICULA peliculaEntity { get; set; }
        public ADMINISTRADOR administradorEntity { get; set; }
        public USUARIO usuarioEntity { get; set; }
        public CineEntities ctx { get; set; }

        public RepositorioManager()
        {
            ctx = new CineEntities();//es el nombre que le di a la base de datos
            carteleraEntity = new CARTELERA();
            sedeEntity = new SEDE();
            reservaEntity = new RESERVA();
            reporteEntity = new REPORTES_DE_RESERVAS();
            peliculaEntity = new PELICULA();
            administradorEntity = new ADMINISTRADOR();
            usuarioEntity = new USUARIO();
           
               
        }
    }
}