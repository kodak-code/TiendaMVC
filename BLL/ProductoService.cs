using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductoService
    {
        private DAL.ProductoDataAccess productoDAL = new DAL.ProductoDataAccess();

        public List<BE.Producto> Listar()
        {
            return productoDAL.Listar();
        }

        public int Crear(BE.Producto producto, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                mensaje = "El Producto debe tener un Nombre";

            else if (string.IsNullOrWhiteSpace(producto.Descripcion))
                mensaje = "El Producto debe tener una Descripcion";

            else if (producto.Marca?.IdMarca == 0)
                mensaje = "El Producto debe tener una Marca";
            
            else if (producto.Categoria?.IdCategoria == 0)
                mensaje = "El Producto debe tener una Categoria";
            
            else if (producto.Stock == 0)
                mensaje = "El Producto debe tener un Stock";
            
            else if (producto.Precio == 0)
                mensaje = "El Producto debe tener un Precio";

            if (string.IsNullOrEmpty(mensaje))
            {
                return productoDAL.Crear(producto, out mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(BE.Producto producto, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                mensaje = "El Producto debe tener un Nombre";

            else if (string.IsNullOrWhiteSpace(producto.Descripcion))
                mensaje = "El Producto debe tener una Descripcion";

            else if (producto.Marca?.IdMarca == 0)
                mensaje = "El Producto debe tener una Marca";

            else if (producto.Categoria?.IdCategoria == 0)
                mensaje = "El Producto debe tener una Categoria";

            else if (producto.Stock == 0)
                mensaje = "El Producto debe tener un Stock";

            else if (producto.Precio == 0)
                mensaje = "El Producto debe tener un Precio";

            if (string.IsNullOrEmpty(mensaje))
            {
                return productoDAL.Editar(producto, out mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool GuardarDatosImagen(BE.Producto producto, out string mensaje)
        {
            return productoDAL.GuardarDatosImagen(producto, out mensaje);
        }

        public bool Desactivar(int IdProducto, out string mensaje)
        {
            return productoDAL.Desactivar(IdProducto, out mensaje);
        }
    }
}