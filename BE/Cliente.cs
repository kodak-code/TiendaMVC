using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cliente
    {

        private int _idCliente;

        public int IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _apellido;

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        private string _correo;

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        private string _clave;

        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }

        private bool _reestablecer;

        public bool Reestablecer
        {
            get { return _reestablecer; }
            set { _reestablecer = value; }
        }

    }
}
