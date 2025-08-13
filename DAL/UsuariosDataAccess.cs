using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Clase de acceso a datos para la entidad Usuario.
    /// Proporciona métodos para listar, crear y editar usuarios en la base de datos.
    /// </summary>
    public class UsuariosDataAccess
    {
        /// <summary>
        /// Obtiene la lista de todos los usuarios registrados en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos Usuario.</returns>
        public List<BE.Usuario> Listar()
        {
            Conexion conexion = new Conexion();

            List<BE.Usuario> usuarios = new List<BE.Usuario>();

            DataTable dt = conexion.LeerPorStoreProcedure("sp_listar_usuarios");

            foreach (DataRow fila in dt.Rows)
            {
                BE.Usuario unUsuario = new BE.Usuario();
                unUsuario.IdUsuario = Convert.ToInt32(fila["IdUsuario"]);
                unUsuario.Nombre = fila["Nombre"].ToString();
                unUsuario.Apellido = fila["Apellido"].ToString();
                unUsuario.Correo = fila["Correo"].ToString();
                unUsuario.Clave = fila["Clave"].ToString();
                unUsuario.Reestablecer = Convert.ToBoolean(fila["Reestablecer"]);
                unUsuario.Activo = Convert.ToBoolean(fila["Activo"]);
                unUsuario.FechaRegistro = Convert.ToDateTime(fila["FechaRegistro"]);

                usuarios.Add(unUsuario);
            }

            return usuarios;
        }

        /// <summary>
        /// Crea un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuario">Objeto Usuario con los datos a registrar.</param>
        /// <param name="mensaje">Mensaje de resultado de la operación.</param>
        /// <returns>Identificador del usuario creado (0 si falla).</returns>
        public int Crear(BE.Usuario usuario, out string mensaje)
        {
            Conexion conexion = new Conexion();

            int resultado = 0;
            mensaje = string.Empty;

            SqlParameter[] parametros = new SqlParameter[]
            {
                    new SqlParameter("@Nombre", usuario.Nombre),
                    new SqlParameter("@Apellido", usuario.Apellido),
                    new SqlParameter("@Correo", usuario.Correo),
                    new SqlParameter("@Clave", usuario.Clave),
                    new SqlParameter("@Activo", usuario.Activo),
                    new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Resultado", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            int filasAfectadas = conexion.EscribirPorStoreProcedure("sp_crear_usuario", parametros);

            mensaje = parametros[5].Value.ToString();
            resultado = Convert.ToInt32(parametros[6].Value);

            return resultado;
        }

        /// <summary>
        /// Edita los datos de un usuario existente en la base de datos.
        /// </summary>
        /// <param name="usuario">Objeto Usuario con los datos actualizados.</param>
        /// <param name="mensaje">Mensaje de resultado de la operación.</param>
        /// <returns>True si la edición fue exitosa, False en caso contrario.</returns>
        public bool Editar(BE.Usuario usuario, out string mensaje)
        {
            Conexion conexion = new Conexion();

            bool resultado = false;
            mensaje = string.Empty;

            SqlParameter[] parametros = new SqlParameter[]
            {
                    new SqlParameter("@IdUsuario", usuario.IdUsuario),
                    new SqlParameter("@Nombre", usuario.Nombre),
                    new SqlParameter("@Apellido", usuario.Apellido),
                    new SqlParameter("@Correo", usuario.Correo),
                    new SqlParameter("@Activo", usuario.Activo),
                    new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Resultado", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            int filasAfectadas = conexion.EscribirPorStoreProcedure("sp_editar_usuario", parametros);

            mensaje = parametros[5].Value.ToString();
            resultado = Convert.ToBoolean(parametros[6].Value);

            return resultado;
        }

        public bool Desactivar(int IdUsuario, out string mensaje)
        {
            Conexion conexion = new Conexion();

            bool resultado = false;
            mensaje = string.Empty;

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", IdUsuario),
                new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output },
                new SqlParameter("@Resultado", SqlDbType.Bit) { Direction = ParameterDirection.Output }
            };

            int filasAfectadas = conexion.EscribirPorStoreProcedure("sp_desactivar_usuario", parametros);

            mensaje = parametros[1].Value.ToString();
            resultado = Convert.ToBoolean(parametros[2].Value);

            return resultado;
        }
    }
}