using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sugeno
{
    class Item
    {
        public string Label { get; }
        public List<(string, double)> Values { get; } = new List<(string, double)>();
        
        public Item(string label, params (string, double)[] values)
        {
            Label = label;
            foreach (var item in values)
            {
                Values.Add(item);
            }
        }
    }
}
