using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Departamento
    {

        private int _idDepartamente;

        public int IdDepartamente
        {
            get { return _idDepartamente; }
            set { _idDepartamente = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

    }
}
