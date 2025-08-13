using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Producto
    {
        private int _idProducto;
        public int IdProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private Marca _marca;
        public Marca Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        private Categoria _categoria;
        public Categoria Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        private decimal _precio;
        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        private int _stock;
        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        private string _rutaImagen;
        public string RutaImagen
        {
            get { return _rutaImagen; }
            set { _rutaImagen = value; }
        }

        private string _nombreImagen;
        public string NombreImagen
        {
            get { return _nombreImagen; }
            set { _nombreImagen = value; }
        }

        private bool _activo;
        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

    }
}
