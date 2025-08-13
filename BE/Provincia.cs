using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Provincia
    {
        private int _idProvincia;
        public int IdProvincia
        {
            get { return _idProvincia; }
            set { _idProvincia = value; }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

    }
}