using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Entity;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    //Esta clase la uso mas para la parte visual, tipar las vistas, y manejar 
    //pasaje de parametros
    public class SedeModelAndView : SEDE
    {
        
        public string  idSede { get; set; }
        //Le comente los required porque me explota algo, igual lo valide en Backend
        //[Required (ErrorMessage ="Por favor ingrese el nombre de la sede")]
        [MaxLength (30,ErrorMessage ="El nombre de la sede no puede ser mayor a 30 caracteres")]
        public string nombreSede { get; set; }

        //[Required(ErrorMessage = "Por favor ingrese la dirección de la sede")]
        [MaxLength(30, ErrorMessage = "La dirección de la sede no puede ser mayor a 30 caracteres")]
        public string direccionSede { get; set; }

        //[Required(ErrorMessage = "Por favor ingrese el precio de la sede")]
        [RegularExpression("[0-9]", ErrorMessage = "Son solo valido numeros en este campo")]
        [MaxLength(30, ErrorMessage = "El precio de la sede no puede ser mayor a 30 caracteres")]
        public string precioEntradaGeneral { get; set; }

        //Lo uso para listar sedes
        
        public List<SEDE> listadoDeSedes { get; set; }

        //aca creo un constructor donde seteo los valores de la clase de la bdd a las propiedades
        //de mi modelAndView
        public SedeModelAndView()
        {
            this.idSede = ID.ToString();
            this.nombreSede = NOMBRE;
            this.direccionSede = DIRECCION;
            this.precioEntradaGeneral = PRECIO_ENTRADA_GENERAL.ToString();
        }

    }
}