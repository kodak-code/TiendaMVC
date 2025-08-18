using BE;
using BE.DTOs;
using IUAdmin.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class DashboardDataAccess
    {

        public List<Reporte> VerReporte()
        {
            Conexion conexion = new Conexion();

            List<Reporte> reportes = new List<Reporte>();

            DataTable dt = conexion.LeerPorStoreProcedure("sp_reporte_dashboard");

            foreach (DataRow fila in dt.Rows)
            {
                Reporte unReporte = new Reporte();
                unReporte.TotalCliente = Convert.ToInt32(fila["TotalCliente"]);
                unReporte.TotalVenta = Convert.ToInt32(fila["TotalVenta"]); 
                unReporte.TotalProducto = Convert.ToInt32(fila["TotalProducto"]);

                reportes.Add(unReporte);
            }
            return reportes;
        }

        public List<HistorialVenta> VerHistorialVenta(string fechaInicio, string fechaFin, int? idTransaccion)
        {
            Conexion conexion = new Conexion();

            List<HistorialVenta> historialVentas = new List<HistorialVenta>();

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@FechaInicio", fechaInicio),
                new SqlParameter("@FechaFin", fechaFin),
                new SqlParameter("@IdTransaccion", (object)idTransaccion ?? DBNull.Value)
            };

            DataTable dt = conexion.LeerPorStoreProcedure("sp_reporte_ventas", parametros);

            foreach (DataRow fila in dt.Rows)
            {
                HistorialVenta unHistorialVenta = new HistorialVenta();
                unHistorialVenta.FechaVenta = fila["FechaVenta"].ToString();
                unHistorialVenta.Cliente = fila["Cliente"].ToString();
                unHistorialVenta.Producto = fila["Producto"].ToString();
                unHistorialVenta.Precio = Convert.ToDecimal(fila["Precio"], new CultureInfo("es-AR"));
                unHistorialVenta.Cantidad = Convert.ToInt32(fila["Cantidad"]);
                unHistorialVenta.Total = Convert.ToInt32(fila["Total"], new CultureInfo("es-AR"));
                unHistorialVenta.IdTransaccion = Convert.ToInt32(fila["IdTransaccion"]);

                historialVentas.Add(unHistorialVenta);
            }
            return historialVentas;
        }

    }
}
