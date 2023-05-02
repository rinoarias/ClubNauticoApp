using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLayer
{
    public class DSLPuertoDestino
    {
        private int _idPuerto;
        private DSLCiudad _ciudad;
        private string _nombrePuerto;

        public int IdPuerto { get => _idPuerto; set => _idPuerto = value; }
        public DSLCiudad Ciudad { get => _ciudad; set => _ciudad = value; }
        public string NombrePuerto { get => _nombrePuerto; set => _nombrePuerto = value; }
    }
}
