using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ModelAndViewLogin
    {
        
        [RegularExpression("^[a-zA-Z0-9\040]+$",ErrorMessage ="Caráctetes no validos")]
        [StringLength(12, ErrorMessage = "El nombre no puede contener más de 12 caracteres")]
        [Required(ErrorMessage = "Ingrese su nombre")]
        public string nombre { get; set; }

        [MinLength (8 , ErrorMessage ="La contraseña debe tener por lo menos 8 carácteres")]
        [StringLength(20, ErrorMessage = "La contraseña no puede contener más de 20 caracteres")]
        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        public string contraseña { get; set; }
    }
}