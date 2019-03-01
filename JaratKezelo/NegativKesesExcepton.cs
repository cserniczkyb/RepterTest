using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezelo
{
    class NegativKesesExcepton: Exception
    {
        public NegativKesesExcepton(string jaratszam)
            : base("Hibas keses: " + jaratszam)
        {
        }
    }
}
