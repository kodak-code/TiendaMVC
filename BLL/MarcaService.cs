using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MarcaService
    {
        private DAL.MarcaDataAccess marcaDAL = new DAL.MarcaDataAccess();
        public List<BE.Marca> Listar()
        {
            return marcaDAL.Listar();
        }
    
        public int Crear(BE.Marca marca, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(marca.Descripcion))
                mensaje = "La marca debe tener una descripcion";

            if (string.IsNullOrEmpty(mensaje))
            {
                return marcaDAL.Crear(marca, out mensaje);
            } 
            else
            {
                return 0;
            }
        }

        public bool Editar(BE.Marca marca, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(marca.Descripcion))
                mensaje = "La marca debe tener una descripcion";

            if (string.IsNullOrEmpty(mensaje))
            {
                return marcaDAL.Editar(marca, out mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Desactivar(int IdMarca, out string mensaje)
        {
            return marcaDAL.Desactivar(IdMarca, out mensaje);
        }
    }
}
