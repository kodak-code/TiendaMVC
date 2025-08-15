using BE;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
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

        #region CATEGORIA
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

        #endregion

        #region MARCA
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
        #endregion

        #region PRODUCTO

        [HttpGet]
        public JsonResult ListarProductos()
        {
            List<BE.Producto> oLista = new List<BE.Producto>();

            oLista = new BLL.ProductoService().Listar();

            var productosFormateados = oLista.Select(e => new
            {
                e.IdProducto,
                e.Nombre,
                e.Descripcion,
                Marca = new 
                { 
                    e.Marca.IdMarca,
                    e.Marca.Descripcion
                },
                Categoria = new
                {               
                    e.Categoria.IdCategoria,
                    e.Categoria.Descripcion
                },
                e.Stock,
                e.Precio,
                e.RutaImagen,
                e.NombreImagen,
                e.Activo
            });

            return Json(new { data = productosFormateados }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarProducto(string objeto, HttpPostedFileBase archivoImagen)
        {
            string mensaje = string.Empty;
            bool operacionExitosa = true; // seria el resultado
            bool guardarImagenExito = true;
            decimal precio;

            BE.Producto oProducto = new BE.Producto();
            oProducto = JsonConvert.DeserializeObject<BE.Producto>(objeto);

            // Registrar precio
            if(decimal.TryParse(oProducto.PrecioTexto,NumberStyles.AllowDecimalPoint,new CultureInfo("es-AR"), out precio))
            {
                oProducto.Precio = precio;
            } else
            {
                return Json(new { operacionExitosa = false, mensaje = "El formato del precio es incorrecto" }, JsonRequestBehavior.AllowGet);
            }

            // Registrar producto
            if (oProducto.IdProducto == 0)
            {
                int idProductoGenerado = new BLL.ProductoService().Crear(oProducto, out mensaje);

                if(idProductoGenerado != 0)
                {
                    oProducto.IdProducto = idProductoGenerado;
                } 
                else
                {
                    operacionExitosa = false;
                }
            }
            else
            {
                operacionExitosa = new BLL.ProductoService().Editar(oProducto, out mensaje);
            }

            // Registrar imagen
            if(operacionExitosa)
            {
                if(archivoImagen != null)
                {
                    string rutaGuardar = ConfigurationManager.AppSettings["ServidorFotos"];
                    string extension = Path.GetExtension(archivoImagen.FileName);
                    string nombreImagen = string.Concat(oProducto.IdProducto.ToString(), extension);

                    try
                    {
                        archivoImagen.SaveAs(Path.Combine(rutaGuardar, nombreImagen));
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                        guardarImagenExito = false;
                    }

                    if(guardarImagenExito)
                    {
                        oProducto.RutaImagen = rutaGuardar;
                        oProducto.NombreImagen = nombreImagen;

                        bool rspta = new BLL.ProductoService().GuardarDatosImagen(oProducto, out mensaje);
                    } else
                    {
                        mensaje = "Se guardo la el producto pro hubo problemas con la imagen";
                    }

                }
            }

            return Json(new { operacionExitosa = operacionExitosa, idGenerado = oProducto.IdProducto, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        // Rutear imagen
        [HttpPost]
        public JsonResult ImagenProducto(int id)
        {
            bool conversion;
            Producto oProducto = new BLL.ProductoService().Listar().Where(p => p.IdProducto == id).FirstOrDefault();
            string textoBase64 = BLL.Recursos.ConvertirBase64(Path.Combine(oProducto.RutaImagen, oProducto.NombreImagen), out conversion);

            return Json(new
            {
                conversion = conversion,
                textoBase64 = textoBase64,
                extension = Path.GetExtension(oProducto.NombreImagen)
            },
            JsonRequestBehavior.AllowGet
            );
        }

        [HttpPost]
        public JsonResult DesactivarProducto(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BLL.ProductoService().Desactivar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}