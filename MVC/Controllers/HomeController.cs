using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult inicio()
        {
            
            return View();
        }

        public ActionResult login()
        {
            ModelAndViewLogin modeloLogin = new ModelAndViewLogin();
           return View(modeloLogin);
        }

        [HttpPost]
        public ActionResult login( ModelAndViewLogin model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
                
            }

            TempData["Mensaje"] = "Bienvenido/a " + model.nombre;
            return RedirectToAction("inicio");

            /* ViewBag.bienvenido = ("Bienvenido " + model.nombre);//no anda ver bien dps con la bdd
            return Redirect("/Administracion/inicio"); */
        }
    }
}