using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sugeno
{
    class Trapezoid : IFuzzifier
    {
        private double _a, _b, _c, _d;
        public string Label { get; }

        public Trapezoid(double a, double b, double c, double d, string label)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
            Label = label;
        }

        public double Fuzzify(double x)
        {
            if ((x > _a) && (x <= _b)) return (x - _a) / (_b - _a);
            if ((x > _b) && (x < _c)) return 1;
            if ((x > _c) && (x <= _d)) return (_d - x) / (_d - _c);
            return 0;
        }
    }
}
