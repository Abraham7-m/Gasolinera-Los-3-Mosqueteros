using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasolineraLos3Mosqueteros
{
    internal class Bomba
    {
        public int Id { get; set; }
        public string Estado { get; set; }

        public Bomba(int id)
        {
            Id = id;
            Estado = "Libre";
        }
    }
}
