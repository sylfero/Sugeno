using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sugeno
{
    interface IFuzzifier
    {
        string Label { get; }

        double Fuzzify(double x);
    }
}
