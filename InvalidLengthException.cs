using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_SidneyWackenier
{
    class InvalidLengthException : ApplicationException
    {
        public override string ToString()
        {
            return "ISBN-Nummer moet exact 13 cijfers zijn!";
        }
    }
}
