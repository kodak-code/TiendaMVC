using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoDataAccess
    {
        public List<BE.Producto> Listar()
        {
            Conexion conexion = new Conexion();

            List<BE.Producto> productos = new List<BE.Producto>();

            DataTable dt = conexion.LeerPorStoreProcedure("sp_listar_productos");

            foreach (DataRow fila in dt.Rows)
            {
                BE.Producto unProducto = new BE.Producto();
                unProducto.IdProducto = Convert.ToInt32(fila["IdProducto"]);
                unProducto.Nombre = fila["NombreProducto"].ToString();
                unProducto.Descripcion = fila["Descripcion"].ToString();
                unProducto.Stock = Convert.ToInt32(fila["Stock"]);
                unProducto.Precio = Convert.ToDecimal(fila["Precio"]);
                unProducto.RutaImagen = fila["RutaImagen"].ToString();
                unProducto.NombreImagen = fila["NombreImagen"].ToString(); ;
                unProducto.Activo = Convert.ToBoolean(fila["Activo"]);

                BE.Marca unaMarca = new BE.Marca();
                unaMarca.IdMarca = Convert.ToInt32(fila["IdMarca"]);
                unaMarca.Descripcion = fila["DescripcionMarca"].ToString();
                unProducto.Marca= unaMarca;

                BE.Categoria unaCategoria = new BE.Categoria();
                unaCategoria.IdCategoria = Convert.ToInt32(fila["IdCategoria"]);
                unaCategoria.Descripcion = fila["DescripcionCategoria"].ToString();
                unProducto.Categoria= unaCategoria;

                productos.Add(unProducto);
            }
            return productos;
        }

        public int Crear(BE.Producto producto, out string mensaje)
        {
            Conexion conexion = new Conexion();

            int resultado = 0;
            mensaje = string.Empty;

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Nombre", producto.Nombre),
                new SqlParameter("@Descripcion", producto.Descripcion),
                new SqlParameter("@IdMarca", producto.Marca.IdMarca),
                new SqlParameter("@IdCategoria", producto.Categoria.IdCategoria),
                new SqlParameter("@Precio", producto.Precio),
                new SqlParameter("@Stock", producto.Stock),
                new SqlParameter("@Activo", producto.Activo),
                new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output },
                new SqlParameter("@Resultado", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            int filasAfectadas = conexion.EscribirPorStoreProcedure("sp_crear_producto", parametros);

            mensaje = parametros[7].Value.ToString();
            resultado = Convert.ToInt32(parametros[8].Value);

            return resultado;
        }

        public bool GuardarDatosImagen(BE.Producto producto, out string mensaje)
        {
            Conexion conexion = new Conexion();

            bool resultado = false;
            mensaje = string.Empty;

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdProducto", producto.IdProducto),
                new SqlParameter("@RutaImagen", producto.RutaImagen),
                new SqlParameter("@NombreImagen", producto.NombreImagen)
            };

            int filasAfectadas = conexion.EscribirPorStoreProcedure("sp_guardar_imagen", parametros);

            if(filasAfectadas > 0)
            {
                resultado = true;
            } else
            {
                mensaje = "No se pudo actualizar la imagen";
            }

            return resultado;
        }

        public bool Editar(BE.Producto producto, out string mensaje)
        {
            Conexion conexion = new Conexion();

            bool resultado = false;
            mensaje = string.Empty;

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdProducto", producto.IdProducto),
                new SqlParameter("@Nombre", producto.Nombre),
                new SqlParameter("@Descripcion", producto.Descripcion),
                new SqlParameter("@IdMarca", producto.Marca.IdMarca),
                new SqlParameter("@IdCategoria", producto.Categoria.IdCategoria),
                new SqlParameter("@Precio", producto.Precio),
                new SqlParameter("@Stock", producto.Stock),
                new SqlParameter("@Activo", producto.Activo),
                new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output },
                new SqlParameter("@Resultado", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            int filasAfectadas = conexion.EscribirPorStoreProcedure("sp_editar_producto", parametros);

            mensaje = parametros[8].Value.ToString();
            resultado = Convert.ToBoolean(parametros[9].Value);

            return resultado;
        }

        public bool Desactivar(int IdProducto, out string mensaje)
        {
            Conexion conexion = new Conexion();

            mensaje = string.Empty;
            bool resultado = false;

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdProducto", IdProducto),
                new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output },
                new SqlParameter("@Resultado", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            int filasAfectadas = conexion.EscribirPorStoreProcedure("sp_desactivar_producto", parametros);

            mensaje = parametros[1].Value.ToString();
            resultado = Convert.ToBoolean(parametros[2].Value);

            return resultado;
        }
    }
}
