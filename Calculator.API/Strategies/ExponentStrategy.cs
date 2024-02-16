using Calculator.API.Attributes;
using Calculator.API.Contracts;
using Calculator.API.Models;

namespace Calculator.API.Strategies
{
    [Operation("Exponent", "^", "Raises the first operand to the power of the second operand.", Operator.Exponent)]
    public class ExponentStrategy : ICalculationStrategy
    {
        public decimal Calculate(decimal[] operands)
        {
            if (operands.Length < 2)
            {
                throw new ArgumentException("Exponent operation requires at least two operands.");
            }

            return (decimal)Math.Pow((double)operands[0], (double)operands[1]);
        }
    }
}
