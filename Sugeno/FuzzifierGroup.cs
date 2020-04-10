using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sugeno
{
    class FuzzifierGroup
    {
        public string Label { get; }
        public List<IFuzzifier> Fuzzifiers;

        public FuzzifierGroup(List<IFuzzifier> fuzzifiers, string label)
        {
            Fuzzifiers = fuzzifiers.ToList();
            Label = label;
        }
    }
}
