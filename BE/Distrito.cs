using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Distrito
    {
        private int _idDistrito;
        public int IdDistrito
        {
            get { return _idDistrito; }
            set { _idDistrito = value; }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}
