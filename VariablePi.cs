using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    class VariablePi : IVariable
    {
        public double Value
        {
            get { return 22D / 7D; }
        }

        public VariablePi()
        {
        }
    }
}
