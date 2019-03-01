using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezelo
{
    public class JaratKezelo
    {
        class Jarat
        {
            public Jarat(string jarat, string honnanRepter, string hovaRepter, DateTime indulas, int keses = 0)
            {
                this.jarat = jarat;
                this.honnanRepter = honnanRepter;
                this.hovaRepter = hovaRepter;
                this.indulas = indulas;
                this.keses = keses;
            }

            public string jarat { get; set; }
            public string honnanRepter { get; set; }
            public string hovaRepter { get; set; }
            public DateTime indulas { get; set; }
            public int keses { get; set; }

        }

        List<Jarat> jaratok = new List<Jarat>();

        public void UjJarat(string jaratszam, string repterHonnan, string repterHova, DateTime indulas)
        {
            var jarat = new Jarat(jaratszam, repterHonnan, repterHova, indulas);
            foreach (var jaratkeres in jaratok)
            {
                if (jaratkeres.jarat.Equals(jaratszam))
                {
                    throw new ArgumentException();
                }
            }
            jaratok.Add(jarat);
        }

        public void Keses(string jaratszam, int keses)
        {
            foreach (var jarat in jaratok)
            {
                if (jarat.jarat.Equals(jaratszam))
                {
                    jarat.keses += keses;
                    if (jarat.keses < 0)
                    {
                        throw new NegativKesesExcepton(jaratszam);
                    }
                }
            }
        }

        public DateTime MikorIndul(string jaratszam)
        {
            foreach (var jarat in jaratok)
            {
                if (jarat.jarat.Equals(jaratszam))
                {
                    jarat.indulas.AddMinutes(jarat.keses);
                    return jarat.indulas;
                }
            }
            throw new ArgumentException();
        }

        public List<string> JaratokRepuloterrol(string repter)
        {
            List<string> repterJarat = new List<string>();

            foreach (var jarat in jaratok)
            {
                if (jarat.honnanRepter.Equals(repter))
                {
                    repterJarat.Add(jarat.jarat);
                }
            }
            if (repterJarat.Count == 0)
            {
                throw new ArgumentException();
            }
            else
            {
                return repterJarat;
            }
        }


    }

}
