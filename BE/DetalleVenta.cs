using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DetalleVenta
    {

        private int _idDetalleVenta;

        public int IdDetalleVenta
        {
            get { return _idDetalleVenta; }
            set { _idDetalleVenta = value; }
        }

        private int _idVenta;
        public int IdVenta
        {
            get { return _idVenta; }
            set { _idVenta = value; }
        }

        private Producto _producto;
        public Producto Producto
        {
            get { return _producto; }
            set { _producto = value; }
        }

        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private decimal _total;
        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private string _idTransaccion;
        public string IdTransaccion
        {
            get { return _idTransaccion; }
            set { _idTransaccion = value; }
        }
    }
}
