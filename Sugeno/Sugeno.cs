using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sugeno
{
    static class Sugeno
    {
        public static double Calculate(this Item input, List<Rule> rules, params FuzzifierGroup[] fuzzifiers)
        {
            (string, double)[][] fuzzifiedValues = new (string, double)[fuzzifiers.Length][];
            double final;

            for (int i = 0; i < fuzzifiers.Length; i++)
            {
                fuzzifiedValues[i] = new (string, double)[fuzzifiers[i].Fuzzifiers.Count];
                
                for (int j = 0; j < fuzzifiers[i].Fuzzifiers.Count; j++)
                {
                    fuzzifiedValues[i][j] = (fuzzifiers[i].Fuzzifiers[j].Label, fuzzifiers[i].Fuzzifiers[j].Fuzzify(input.Values.Find(x => x.Item1.Equals(fuzzifiers[i].Label)).Item2));
                }
            }

            List<double> results = new List<double>();
            
            foreach (var rule in rules)
            {
                List<double> tmpList = new List<double>();
                for (int i = 0; i < fuzzifiedValues.Length; i++)
                {
                    tmpList.Add(fuzzifiedValues[i].ToList().Find(x => x.Item1.Equals(rule.Rules[i].Item2)).Item2);
                }
                results.Add(tmpList.Max());
            }

            double decision = 0;
            for (int i = 0; i < rules.Count; i++)
            {
                decision += results[i] * rules[i].Value;
            }
            double tmp = 0;
            for (int i = 0; i < results.Count; i++)
            {
                tmp += results[i];
            }
            final = decision / tmp;
            return final;
        }
    }
}
