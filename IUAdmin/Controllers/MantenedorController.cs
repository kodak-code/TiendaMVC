using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IUAdmin.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Categoria()
        {
            return View();
        }
        
        public ActionResult Marca()
        {
            return View();
        }
        
        public ActionResult Producto()
        {
            return View();
        }

        // Metodos

        // ----------------------------------------------------------------------------------------------------------------------------//
        [HttpGet]
        public JsonResult ListarCategorias()
        {
            List<BE.Categoria> oLista = new List<BE.Categoria>();

            oLista = new BLL.CategoriaService().Listar();

            var categoriasFormateadas = oLista.Select(e => new
            {
                e.IdCategoria,
                e.Descripcion,
                e.Activo
            });

            return Json(new { data = categoriasFormateadas }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarCategoria(BE.Categoria oCategoria)
        {

            object resultado;
            string mensaje = string.Empty;

            if (oCategoria.IdCategoria == 0)
            {
                resultado = new BLL.CategoriaService().Crear(oCategoria, out mensaje);
            }
            else
            {
                resultado = new BLL.CategoriaService().Editar(oCategoria, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DesactivarCategoria(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BLL.CategoriaService().Desactivar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        // ----------------------------------------------------------------------------------------------------------------------------//

        [HttpGet]
        public JsonResult ListarMarcas()
        {
            List<BE.Marca> oLista = new List<BE.Marca>();
            oLista = new BLL.MarcaService().Listar();

            var marcasFormateadas = oLista.Select(e => new
            {
                e.IdMarca,
                e.Descripcion,
                e.Activo
            });

            return Json(new { data = marcasFormateadas }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarMarca(BE.Marca oMarca)
        {

            object resultado;
            string mensaje = string.Empty;

            if (oMarca.IdMarca == 0)
            {
                resultado = new BLL.MarcaService().Crear(oMarca, out mensaje);
            }
            else
            {
                resultado = new BLL.MarcaService().Editar(oMarca, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DesactivarMarca(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BLL.MarcaService().Desactivar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}