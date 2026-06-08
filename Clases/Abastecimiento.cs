using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasolineraLos3Mosqueteros
{
    public class Abastecimiento
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string Nit { get; set; }
        public int Bomba { get; set; }
        public string Tipo { get; set; }
        public double Litros { get; set; }
        public double Total { get; set; }
        public string TipoGasolina { get; set; }
        public double PrecioLitro { get; set; }

        public Abastecimiento()
        {
            Fecha = DateTime.Now;
        }
    }
}
