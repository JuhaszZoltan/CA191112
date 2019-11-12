using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA191112
{
    class Program
    {
        static Dictionary<string, List<Jatekos>> csapatok;
        static int jatekosokSzama;
        static void Main(string[] args)
        {
            Beolvas();
            Tesztek();
            Console.ReadKey();
        }

        private static void Tesztek()
        {
            Console.WriteLine($"{csapatok["Chicago Bulls"][0].Nev}");

            int osszFizu = 0;
            foreach (var j in csapatok["Chicago Bulls"])
            {
                osszFizu += j.Fizets;
            }

            var atlag = ((float)osszFizu / csapatok["Chicago Bulls"].Count) / 12 * 303.40 * 1.18F;

            Console.WriteLine("Átlagos havi fizus a CB-ban: {0:N3}", atlag);


            //---------------------

            long of = 0;

            foreach (var cs in csapatok)
            {
                foreach (var j in cs.Value)
                {
                    of += j.Fizets;
                }
            }

            var osszatlag = of / (float)jatekosokSzama;

            Console.WriteLine("átlag fizu: {0:N}", of / (float)jatekosokSzama / 12 * 303.4 * 1.18);

            var dic = new Dictionary<string, int>();

            foreach (var cs in csapatok)
            {
                int dbAtlagFelatt = 0;
                foreach (var j in cs.Value)
                {
                    if (j.Fizets > osszatlag) dbAtlagFelatt++;
                }
                dic.Add(cs.Key, dbAtlagFelatt);
            }

            foreach (KeyValuePair<string, int> kvp in dic)
            {
                Console.WriteLine("{0, 23}:  - {1} db", kvp.Key, kvp.Value);
            }
        }

        private static void Beolvas()
        {
            csapatok = new Dictionary<string, List<Jatekos>>();
            var sr = new StreamReader("NBA2003.csv", Encoding.UTF8);

            jatekosokSzama = int.Parse(sr.ReadLine());

            while (!sr.EndOfStream)
            {
                var t = sr.ReadLine().Split(';');
                var csapat = t[0].Trim('"');
                var nev = t[1].Trim('"');
                var fizu = int.Parse(t[2]);
                var evek = int.Parse(t[3]);
                if(!csapatok.ContainsKey(csapat))
                {
                    csapatok.Add(csapat, new List<Jatekos>());
                }
                csapatok[csapat].Add(new Jatekos(nev, fizu, evek));
            }
            sr.Close();
        }
    }
}
