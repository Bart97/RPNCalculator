using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    class Variable : IVariable
    {
        private double value;

        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public Variable(double value)
        {
            this.Value = value;
        }
    }
}
