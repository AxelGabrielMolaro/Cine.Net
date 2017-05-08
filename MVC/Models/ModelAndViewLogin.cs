using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ModelAndViewLogin
    {
        [StringLength(12, ErrorMessage = "El nombre no puede contener más de 12 caracteres")]
        [Required(ErrorMessage = "Ingrese su nombre")]
        public string nombre { get; set; }
        [StringLength(12, ErrorMessage = "La contraseña no puede contener más de 12 caracteres")]
        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        public string contraseña { get; set; }
    }
}