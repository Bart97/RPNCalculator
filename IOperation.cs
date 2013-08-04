using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    interface IOperation
    {
        void Execute(Stack<double> stack);
    }
}
