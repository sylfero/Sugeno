using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sugeno
{
    class Triangle : IFuzzifier
    {
        private double _a, _b, _c;
        public string Label { get; }

        public Triangle(double a, double b, double c, string label)
        {
            _a = a;
            _b = b;
            _c = c;
            Label = label;
        }

        public double Fuzzify(double x)
        {
            if ((_a < x) && (x <= _b)) return (x - _a) / (_b - _a);
            if ((_b < x) && (x < _c)) return (_c - x) / (_c - _b);
            return 0;
        }
    }
}
