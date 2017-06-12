using MVC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ReservaModelAndView : Reservas
    {
      

        public string idReservaReservaModel{ get; set; }
        public string idSedeReservaModel { get; set; }
        public string idVersionReservaModel { get; set; }
        public string idPeliculaReservaModel { get; set; }
        public string fechaInicioReservaModel { get; set; }
        public string mailReservaModel { get; set; }
        public string idTipoDocumentoReservaModel { get; set; }
        public string numeroDocumentoReservaModel { get; set; }
        public string cantidadDeEntradasReservaModel { get; set; }
        public string fechaCargaReservaModel { get; set; }
        
        //ver el tema de las funciones

        //listados
        public List<Versiones> listadoDeVersionesReservaModel { get; set; }
        public List<TiposDocumentos> listadoDeTipoDocumentoModel { get; set; }
        public List<Sedes> listadoDeSedesReservaModel { get; set; }

    }
}