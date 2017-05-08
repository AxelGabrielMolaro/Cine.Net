using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ModelAndViewLogin
    {
        [StringLength(12 ,ErrorMessage ="Error en el nombre")]
        public String nombre { get; set; }
        [StringLength(12, ErrorMessage ="Error en el contraseñañ")]
        public String contraseña { get; set; }
    }
}