using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPFinal.Models;

namespace TPFinal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrarse()
        {
            return View();
        }

        public ActionResult Login_OK(Usuario uneUsuarie)
        {
            string unMail = uneUsuarie.Mail1;
            string unaContraseña = uneUsuarie.Contrasena1;
            bool usuarioEncontrado = BD.VerificarUsuario(unMail, unaContraseña);

            if (usuarioEncontrado == true)
            {
                Usuario nuevoUsuario = BD.TraerDatosUsuario(unMail, unaContraseña);
                return View("Home", "Home", nuevoUsuario);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Home(Usuario nuevoUsuario)
        {
            ViewBag.Nombre = nuevoUsuario.Nombre1;
            ViewBag.Puntos = nuevoUsuario.Puntos1;
            ViewBag.Experiencia = nuevoUsuario.Experiencia1;
            ViewBag.Moderador = nuevoUsuario.Moderador1;

            List<Usuario> ListTOP3 = new List<Usuario>();
            ListTOP3 = BD.ListarTOP3();

            ViewBag.Listado = ListTOP3;

            return View();
        }
        public ActionResult ListMaterias()
        {
            List<Materia> ListaMaterias = new List<Materia>();
            ListaMaterias = BD.ListarMaterias();
            ViewBag.ListadoMaterias = ListaMaterias;
            return View();
        }
    }
}