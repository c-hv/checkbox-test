using Calculator.API.Contracts;
using Calculator.API.Models;

namespace Calculator.API.Strategies
{
    public class CalculationStrategyFactory
    {
        public static ICalculationStrategy GetStrategy(Operator op)
        {
            return op switch
            {
                Operator.Add => new AdditionStrategy(),
                Operator.Subtract => new SubtractionStrategy(),
                Operator.Multiply => new MultiplicationStrategy(),
                Operator.Divide => new DivisionStrategy(),
                Operator.Exponent => new ExponentStrategy(),
                _ => throw new ArgumentException("Unsupported operator")
            };
        }
    }
}
