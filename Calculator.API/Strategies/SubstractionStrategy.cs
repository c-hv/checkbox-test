using Calculator.API.Attributes;
using Calculator.API.Contracts;
using Calculator.API.Models;

namespace Calculator.API.Strategies
{
    [Operation("Subtraction", "-", "Subtracts all the operands from the first one.", Operator.Subtract)]
    public class SubtractionStrategy : ICalculationStrategy
    {
        public decimal Calculate(decimal[] operands)
        {
            return operands.Aggregate((a, b) => a - b);
        }
    }
}
