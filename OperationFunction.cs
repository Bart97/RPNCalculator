using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    class OperationFunction: IOperation
    {
        private Function function;
        public OperationFunction(Function _function)
        {
            function = _function;
        }
        public void Execute(Stack<double> stack)
        {
            function(stack);
        }
    }
}
