using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IUAdmin.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CambiarClave()
        {
            return View();
        }
        public ActionResult Reestablecer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string correo, string clave)
        {
            BE.Usuario oUsuario = new BE.Usuario();

            oUsuario = new BLL.UsuarioService().Listar().Where(u => u.Correo == correo && u.Clave == Recursos.ConvertirSha256(clave)).FirstOrDefault();

            if (oUsuario == null)
            {
                // Guarda informacion y la comparte con la vista
                ViewBag.Error = "Correo o contraseña no correcta";
                return View();
            } 
            else
            {
                if (oUsuario.Reestablecer)
                {
                    // Guarda informacion y la comparte con multiples vistas dentro de un controlador
                    TempData["IdUsuario"] = oUsuario.IdUsuario;
                    return RedirectToAction("CambiarClave");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);
                    ViewBag.Error = null;
                    return RedirectToAction("Index", "Home");
                }
            }

        }

        [HttpPost]
        public ActionResult CambiarClave(string idUsuario, string claveActual, string nuevaClave, string confirmarClave)
        {
            BE.Usuario oUsuario = new BE.Usuario();

            oUsuario = new BLL.UsuarioService().Listar().Where(u => u.IdUsuario == int.Parse(idUsuario)).FirstOrDefault();

            // Valaciones
            if (oUsuario.Clave != Recursos.ConvertirSha256(claveActual))
            {
                TempData["IdUsuario"] = idUsuario;
                ViewData["vClave"] = ""; // Permite almacenar valores como texto
                ViewBag.Error = "La contraseña actual no es correcta";
                return View();
            }
            else if (nuevaClave != confirmarClave)
            {
                TempData["IdUsuario"] = idUsuario; // mantener vivo la info temporal
                ViewData["vClave"] = claveActual;
                ViewBag.Error = "Las contraseñas no coinciden";
                return View();
            }

            // Cambio de contraseña

            ViewData["vClave"] = "";

            nuevaClave = Recursos.ConvertirSha256(nuevaClave);

            string mensaje = string.Empty;

            bool respuesta = new UsuarioService().CambiarClave(int.Parse(idUsuario), nuevaClave, out mensaje);

            if(respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["IdUsuario"] = idUsuario;
                ViewBag.Error = mensaje;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Reestablecer(string correo)
        {
            BE.Usuario oUsuario = new BE.Usuario();

            oUsuario = new BLL.UsuarioService().Listar().Where(item => item.Correo == correo).FirstOrDefault();

            if (oUsuario == null)
            {
                ViewBag.Error = "No se encontró un usuario relacionado a ese correo";
                return View();
            }

            string mensaje = string.Empty;
            bool respuesta = new BLL.UsuarioService().ReestablecerClave(oUsuario.IdUsuario, correo, out mensaje);

            if (respuesta)
            {
                ViewBag.Error = null;
                return RedirectToAction("Index", "Acceso");
            }
            else
            {
                ViewBag.Error = mensaje;
                return View();
            }
        }

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Acceso");
        }

    }
}