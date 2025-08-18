using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUAdmin.DTOs
{
	public class Reporte
	{
		private int _totalCliente;

		public int TotalCliente
		{
			get { return _totalCliente; }
			set { _totalCliente = value; }
		}

		private int _totalVenta;

		public int TotalVenta
		{
			get { return _totalVenta; }
			set { _totalVenta = value; }
		}

		private int _totalProducto;

		public int TotalProducto
		{
			get { return _totalProducto; }
			set { _totalProducto = value; }
		}

    }
}