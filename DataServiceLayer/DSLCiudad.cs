using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLayer
{
    public class DSLCiudad
    {
        private int _idCiudad;
        private DSLPais _pais;
        private string _nombreCiudad;

        public int IdCiudad { get => _idCiudad; set => _idCiudad = value; }
        public DSLPais Pais { get => _pais; set => _pais = value; }
        public string NombreCiudad { get => _nombreCiudad; set => _nombreCiudad = value; }
    }
}
