using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.DTOs
{
    public class HistorialVenta
    {
		private string _fechaVenta;

		public string FechaVenta
		{
			get { return _fechaVenta; }
			set { _fechaVenta = value; }
		}

		private string _cliente;

		public string Cliente
		{
			get { return _cliente; }
			set { _cliente = value; }
		}

		private string _producto;

		public string Producto
		{
			get { return _producto; }
			set { _producto = value; }
		}

		private decimal _precio;

		public decimal Precio
		{
			get { return _precio; }
			set { _precio = value; }
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

		private int _idTransaccion;

		public int IdTransaccion
		{
			get { return _idTransaccion; }
			set { _idTransaccion = value; }
		}

	}
}
