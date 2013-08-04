using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    class CompiledExpression
    {
        public List<IOperation> operations;

        public CompiledExpression()
        {
            operations = new List<IOperation>();
        }

        public void Execute(Stack<double> stack)
        {
            foreach (IOperation op in operations)
            {
                op.Execute(stack);
            }
        }
    }
}
