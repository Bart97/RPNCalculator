using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    class OperationPush: IOperation
    {
        private IVariable value;
        public OperationPush(IVariable value)
        {
            this.value = value;
        }
        public void Execute(Stack<double> stack)
        {
            stack.Push(value.Value);
        }
    }
}
