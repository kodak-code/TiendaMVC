using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioService
    {
        private DAL.UsuariosDataAccess usuarioDAL = new DAL.UsuariosDataAccess();

        public List<BE.Usuario> Listar()
        {
            return usuarioDAL.Listar();
        }

        public int Crear(BE.Usuario usuario, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                mensaje = "El Usuario debe tener un Nombre";
            
            else if (string.IsNullOrWhiteSpace(usuario.Apellido))
                mensaje = "El Usuario debe tener un Apellido";
            
            else if (string.IsNullOrWhiteSpace(usuario.Correo))
                mensaje = "El Usuario debe tener un Correo";
            
            // EMAIL
            if(string.IsNullOrEmpty(mensaje))
            {
                string clave = Recursos.GenerarClave();

                string asunto = "Creación de Cuenta";
                string mensajeCorreo = "<h3>Su cuenta fue creada correctamente</h3></br><p>Su contraseña para acceder es: !clave!</p>";
                mensajeCorreo = mensajeCorreo.Replace("!clave!", clave);

                bool respuesta = Recursos.EnviarCorreo(usuario.Correo, asunto, mensajeCorreo);

                
                if (respuesta)
                {
                    usuario.Clave = Recursos.ConvertirSha256(clave);

                    return usuarioDAL.Crear(usuario, out mensaje);
                }
                else
                {
                    mensaje = "No se puede enviar el correo";
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(BE.Usuario usuario, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                mensaje = "El Usuario debe tener un Nombre";

            else if (string.IsNullOrWhiteSpace(usuario.Apellido))
                mensaje = "El Usuario debe tener un Apellido";

            else if (string.IsNullOrWhiteSpace(usuario.Correo))
                mensaje = "El Usuario debe tener un Correo";

            if (string.IsNullOrEmpty(mensaje))
            {
                string clave = "test123";
                usuario.Clave = Recursos.ConvertirSha256(clave);

                return usuarioDAL.Editar(usuario, out mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Desactivar(int IdUsuario, out string mensaje)
        {
            return usuarioDAL.Desactivar(IdUsuario, out mensaje);
        }

        public bool CambiarClave(int idUsuario, string nuevaClave, out string mensaje)
        {
            return usuarioDAL.CambiarClave(idUsuario, nuevaClave, out mensaje);
        }

        public bool ReestablecerClave(int idUsuario, string correo, out string mensaje)
        {
            mensaje = string.Empty;
            string nuevaClave = Recursos.GenerarClave();
            bool resultado = usuarioDAL.ReestablecerClave(idUsuario, Recursos.ConvertirSha256(nuevaClave), out mensaje);

            if (resultado)
            {
                string asunto = "Contraseña Reestablecida";
                string mensajeCorreo = "<h3>Su cuenta fue reestablecida correctamente</h3></br><p>Su contraseña para acceder ahora es: !clave!</p>";
                mensajeCorreo = mensajeCorreo.Replace("!clave!", nuevaClave);

                bool respuesta = Recursos.EnviarCorreo(correo, asunto, mensajeCorreo);

                if (respuesta)
                {
                    return true;
                } else
                {
                    mensaje = "No se pudo enviar el correo";
                    return false;
                }
            }
            else
            {
                mensaje = "No se pudo reestablecer la contraseña";
                return false;
            }
            
        }

    }
}