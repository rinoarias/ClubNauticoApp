using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLayer
{
    public class DSLPais
    {
        private int _idPais;
        private string _nombrePais;

        public int IdPais { get => _idPais; set => _idPais = value; }
        public string NombrePais { get => _nombrePais; set => _nombrePais = value; }
    }
}
