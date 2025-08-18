using BE.DTOs;
using ClosedXML.Excel;
using IUAdmin.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        #region USUARIOS
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
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DesactivarUsuario(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BLL.UsuarioService().Desactivar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        [HttpGet]
        public JsonResult VerReporte()
        {
            List<Reporte> oReporte = new BLL.ReporteService().VerReporte();
            var reportesFormateados = oReporte.Select(e => new
            {
                e.TotalCliente,
                e.TotalVenta,
                e.TotalProducto
            });
            return Json(new { data = reportesFormateados }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult VerHistorialVenta(string fechaInicio, string fechaFin, int? idTransaccion)
        {
            List<HistorialVenta> oReporte = new BLL.ReporteService().VerHistorialVenta(fechaInicio, fechaFin, idTransaccion);
            var historialVentasFormateadas = oReporte.Select(e => new
            {
                e.FechaVenta,
                e.Cliente,
                e.Producto,
                e.Precio,
                e.Cantidad,
                e.Total,
                e.IdTransaccion
            });
            return Json(new { data = historialVentasFormateadas }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public FileResult ExportarVenta(string fechaInicio, string fechaFin, int idTransaccion)
        {
            List<HistorialVenta> oReporte = new BLL.ReporteService().VerHistorialVenta(fechaInicio, fechaFin, idTransaccion);

            DataTable dt = new DataTable();

            dt.Locale = new System.Globalization.CultureInfo("es-AR");
            dt.Columns.Add("Fecha Venta", typeof(string));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("Total", typeof(decimal));
            dt.Columns.Add("IdTransaccion", typeof(int));

            foreach (HistorialVenta hv in oReporte)
            {
                dt.Rows.Add(new object[] {
                    hv.FechaVenta,
                    hv.Cliente,
                    hv.Producto,
                    hv.Precio,
                    hv.Cantidad,
                    hv.Total,
                    hv.IdTransaccion
                });
            }

            dt.TableName = "Datos";

            using (XLWorkbook wb = new XLWorkbook()){
                wb.Worksheets.Add(dt);

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReporteVenta" +
                        DateTime.Now.ToString() + ".xlsx");
                }
            }

        }


    }

}