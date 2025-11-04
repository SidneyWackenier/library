using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_SidneyWackenier
{
    internal class LessThanZeroException : ApplicationException
    {
        public override string ToString()
        {
            return "Jaartal moet later dan 0 zijn!";
        }
    }
}
