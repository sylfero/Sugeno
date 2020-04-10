using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sugeno
{
    class Rule
    {
        public double Value { get; }
        public (string, string)[] Rules { get; }

        public Rule(double value, params (string, string)[] rules)
        {
            Value = value;
            Rules = rules.ToArray();
        }
    }
}
