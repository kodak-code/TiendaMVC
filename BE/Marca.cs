using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Marca
    {
        private int _idMarca;
        public int IdMarca
        {
            get { return _idMarca; }
            set { _idMarca = value; }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private bool _activo;
        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

    }
}
