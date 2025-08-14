using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoriasDataAccess
    {
        public List<BE.Categoria> Listar()
        {
            Conexion conexion = new Conexion();
            List<BE.Categoria> categorias = new List<BE.Categoria>();

            DataTable dt = conexion.LeerPorStoreProcedure("sp_listar_categorias");

            foreach (DataRow fila in dt.Rows)
            {
                BE.Categoria unaCategoria = new BE.Categoria();
                unaCategoria.IdCategoria = Convert.ToInt32(fila["IdCategoria"]);
                unaCategoria.Descripcion = fila["Descripcion"].ToString();
                unaCategoria.Activo = Convert.ToBoolean(fila["Activo"]);

                categorias.Add(unaCategoria);
            }

            return categorias;
        }

        public int Crear(BE.Categoria categoria, out string mensaje)
        {
            Conexion conexion = new Conexion();

            int resultado = 0;
            mensaje = string.Empty;

            SqlParameter[] parametros = new SqlParameter[]
            {
                    new SqlParameter("@Descripcion", categoria.Descripcion),
                    new SqlParameter("@Activo", categoria.Activo),
                    new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Resultado", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            int filasAfectadas = conexion.EscribirPorStoreProcedure("sp_crear_categoria", parametros);

            mensaje = parametros[2].Value.ToString();
            resultado = Convert.ToInt32(parametros[3].Value);

            return resultado;
        }

        public bool Editar(BE.Categoria categoria, out string mensaje)
        {
            Conexion conexion = new Conexion();

            bool resultado = false;
            mensaje = string.Empty;

            SqlParameter[] parametros = new SqlParameter[]
            {
                    new SqlParameter("@IdCategoria", categoria.IdCategoria),
                    new SqlParameter("@Descripcion", categoria.Descripcion),
                    new SqlParameter("@Activo", categoria.Activo),
                    new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Resultado", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            int filasAfectadas = conexion.EscribirPorStoreProcedure("sp_editar_categoria", parametros);

            mensaje = parametros[3].Value.ToString();
            resultado = Convert.ToBoolean(parametros[4].Value);

            return resultado;
        }


        public bool Desactivar(int IdCategoria, out string mensaje)
        {
            Conexion conexion = new Conexion();

            bool resultado = false;
            mensaje = string.Empty;

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdCategoria", IdCategoria),
                new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output },
                new SqlParameter("@Resultado", SqlDbType.Bit) { Direction = ParameterDirection.Output }
            };

            int filasAfectadas = conexion.EscribirPorStoreProcedure("sp_desactivar_categoria", parametros);

            mensaje = parametros[1].Value.ToString();
            resultado = Convert.ToBoolean(parametros[2].Value);

            return resultado;
        }
    }
}
