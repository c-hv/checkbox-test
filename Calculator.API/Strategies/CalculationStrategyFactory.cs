using Calculator.API.Contracts;
using Calculator.API.Models;

namespace Calculator.API.Strategies
{
    public class CalculationStrategyFactory
    {
        public static ICalculationStrategy GetStrategy(string op)
        {
            return op switch
            {
                "+" => new AdditionStrategy(),
                "-" => new SubtractionStrategy(),
                "*" => new MultiplicationStrategy(),
                "/" => new DivisionStrategy(),
                "^" => new ExponentStrategy(),
                "sqrt" => new SquareRootStrategy(),
                _ => throw new ArgumentException("Unsupported operator")
            };
        }
    }
}
