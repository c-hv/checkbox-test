using Calculator.API.Attributes;
using Calculator.API.Contracts;
using Calculator.API.Models;

namespace Calculator.API.Strategies
{
    [Operation("Addition", "+", "Adds all the operands together.")]
    public class AdditionStrategy : ICalculationStrategy
    {
        public decimal Calculate(decimal[] operands)
        {
            return operands.Sum();
        }
    }
}
