using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Venta
    {
        private int _idVenta;
        public int IdVenta
        {
            get { return _idVenta; }
            set { _idVenta = value; }
        }

        private int _idCliente;
        public int IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        private int _totalProducto;
        public int TotalProducto
        {
            get { return _totalProducto; }
            set { _totalProducto = value; }
        }

        private decimal _montoTotal;
        public decimal MontoTotal
        {
            get { return _montoTotal; }
            set { _montoTotal = value; }
        }

        private string _contacto;
        public string Contacto
        {
            get { return _contacto; }
            set { _contacto = value; }
        }

        private string _idDistrito;
        public string IdDistrito
        {
            get { return _idDistrito; }
            set { _idDistrito = value; }
        }

        private string _telefono;
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _direccion;
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private string _fechaTexto;
        public string FechaTexto
        {
            get { return _fechaTexto; }
            set { _fechaTexto = value; }
        }

        private string _idTransaccion;
        public string IdTransaccion
        {
            get { return _idTransaccion; }
            set { _idTransaccion = value; }
        }

        private List<DetalleVenta> _detalleVenta;
        public List<DetalleVenta> DetalleVenta
        {
            get { return _detalleVenta; }
            set { _detalleVenta = value; }
        }

    }
}
