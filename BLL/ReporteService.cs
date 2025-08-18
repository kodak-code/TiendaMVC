using BE.DTOs;
using DAL;
using IUAdmin.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReporteService
    {
        private DashboardDataAccess reporteDAL = new DAL.DashboardDataAccess();

        public List<Reporte> VerReporte()
        {
            return reporteDAL.VerReporte();
        }

        public List<HistorialVenta> VerHistorialVenta(string fechaInicio, string fechaFin, int? idTransaccion)
        {
            return reporteDAL.VerHistorialVenta(fechaInicio, fechaFin, idTransaccion);
        }

     }
}