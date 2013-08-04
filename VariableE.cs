using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    class VariableE : IVariable
    {
        public double Value
        {
            get { return Math.E; }
        }

        public VariableE()
        {
        }
    }
}
