using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IUAdmin.Controllers
{
    public class HomeController : Controller
    {

        // Vistas
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Usuarios()
        {
            return View();
        }

        // Metodos

        // ----------------------------------------------------------------------------------------------------------------------------//
        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<BE.Usuario> oLista = new List<BE.Usuario>();

            oLista = new BLL.UsuarioService().Listar();

            var usuariosFormateados = oLista.Select(e => new
            {
                e.IdUsuario,
                e.Nombre,
                e.Apellido,
                e.Correo,
                e.Clave,
                e.Reestablecer,
                e.Activo,
                FecharRegistro = e.FechaRegistro.ToString("yyyy-MM-dd")
            });

            return Json(new { data = usuariosFormateados }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarUsuarios(BE.Usuario oUsuario)
        {

            object resultado;
            string mensaje = string.Empty;

            if (oUsuario.IdUsuario == 0)
            {
                resultado = new BLL.UsuarioService().Crear(oUsuario, out mensaje);
            }
            else
            {
                resultado = new BLL.UsuarioService().Editar(oUsuario, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DesactivarUsuario(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            
            respuesta = new BLL.UsuarioService().Desactivar(id, out mensaje);
            
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

    }
}