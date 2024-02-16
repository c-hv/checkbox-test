using Calculator.API.Attributes;
using Calculator.API.Contracts;
using Calculator.API.Models;

namespace Calculator.API.Strategies
{
    [Operation("Division", "/", "Divides the first operand by the second.", Operator.Divide)]
    public class DivisionStrategy : ICalculationStrategy
    {
        public decimal Calculate(decimal[] operands)
        {
            if (operands.Length < 2)
            {
                throw new ArgumentException("Divide operation requires at least two operands.");
            }
            if (operands[1] == 0)
            {
                throw new InvalidOperationException("Division by zero is not allowed.");
            }
            return operands[0] / operands[1];
        }
    }
}
