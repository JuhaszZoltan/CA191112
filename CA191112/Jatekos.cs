using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA191112
{
    class Jatekos
    {
        public string Nev { get; set; }
        public int Fizets { get; set; }
        public int Evek { get; set; }

        public Jatekos(string nev, int fizets, int evek)
        {
            Nev = nev;
            Fizets = fizets;
            Evek = evek;
        }
    }
}
