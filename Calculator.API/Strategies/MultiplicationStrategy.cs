using Calculator.API.Attributes;
using Calculator.API.Contracts;
using Calculator.API.Models;

namespace Calculator.API.Strategies
{
    [Operation("Multiplication", "*", "Multiplies all the operands together.", Operator.Multiply)]
    public class MultiplicationStrategy : ICalculationStrategy
    {
        public decimal Calculate(decimal[] operands)
        {
            return operands.Aggregate((a, b) => a * b);
        }
    }
}
