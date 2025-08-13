
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriaService
    {

        private DAL.CategoriasDataAccess categoriaDAL = new DAL.CategoriasDataAccess();

        public List<BE.Categoria> Listar()
        {
            return categoriaDAL.Listar();
        }

        public int Crear(BE.Categoria categoria, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(categoria.Descripcion))
                mensaje = "El Categoria debe tener un Descripcion";

            if (string.IsNullOrEmpty(mensaje))
            {
                return categoriaDAL.Crear(categoria, out mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(BE.Categoria categoria, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(categoria.Descripcion))
                mensaje = "El Categoria debe tener un Descripcion";

            if (string.IsNullOrEmpty(mensaje))
            {
                return categoriaDAL.Editar(categoria, out mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Desactivar(int IdUsuario, out string mensaje)
        {
            return categoriaDAL.Desactivar(IdUsuario, out mensaje);
        }
    }
}