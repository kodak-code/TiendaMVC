using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL
{
    public class MarcaDataAccess
    {
        public List<BE.Marca> Listar()
        {
            Conexion conexion = new Conexion();

            List<BE.Marca> marcas = new List<BE.Marca>();

            DataTable dt = conexion.LeerPorStoreProcedure("sp_listar_marcas");

            foreach (DataRow fila in dt.Rows)
            {
                BE.Marca unaMarca = new BE.Marca();
                unaMarca.IdMarca = Convert.ToInt32(fila["IdMarca"]);
                unaMarca.Descripcion = fila["Descripcion"].ToString();
                unaMarca.Activo = Convert.ToBoolean(fila["Activo"]);

                marcas.Add(unaMarca);
            }
            return marcas;
        }

        public int Crear(BE.Marca marca, out string mensaje)
        {
            Conexion conexion = new Conexion();

            int resultado = 0;
            mensaje = string.Empty;

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Descripcion", marca.Descripcion),
                new SqlParameter("@Activo", marca.Activo),
                new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output },
                new SqlParameter("@Resultado", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            int filasAfectadas = conexion.EscribirPorStoreProcedure("sp_crear_marca", parametros);

            mensaje = parametros[2].Value.ToString();
            resultado = Convert.ToInt32(parametros[3].Value);

            return resultado;
        }

        public bool Editar(BE.Marca marca, out string mensaje)
        {
            Conexion conexion = new Conexion();

            bool resultado = false;
            mensaje = string.Empty;

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdMarca", marca.IdMarca),
                new SqlParameter("@Descripcion", marca.Descripcion),
                new SqlParameter("@Activo", marca.Activo),
                new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output },
                new SqlParameter("@Resultado", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            int filasAfectadas = conexion.EscribirPorStoreProcedure("sp_editar_marca", parametros);

            mensaje = parametros[3].Value.ToString();
            resultado = Convert.ToBoolean(parametros[4].Value);

            return resultado;
        }

        public bool Desactivar(int IdMarca, out string mensaje)
        {
            Conexion conexion = new Conexion();

            mensaje = string.Empty;
            bool resultado = false;

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdMarca", IdMarca),
                new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output },
                new SqlParameter("@Resultado", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            int filasAfectadas = conexion.EscribirPorStoreProcedure("sp_desactivar_marca", parametros);

            mensaje = parametros[1].Value.ToString();
            resultado = Convert.ToBoolean(parametros[2].Value);

            return resultado;
        }
    }
}