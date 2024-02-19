using Calculator.API.Attributes;
using Calculator.API.Contracts;

namespace Calculator.API.Strategies
{
    [Operation("Square root", "sqrt", "Gets the square root of the first operand", 1)]
    public class SquareRootStrategy : ICalculationStrategy
    {
        public decimal Calculate(decimal[] operands)
        {
            if (operands.Length > 1)
            {
                throw new ArgumentException("Square root requires a single operand");
            }

            return (decimal)Math.Sqrt((double)operands[0]);
        }
    }
}
