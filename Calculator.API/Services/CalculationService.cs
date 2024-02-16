using Calculator.API.Contracts;
using Calculator.API.Models;
using Calculator.API.Strategies;

namespace Calculator.API.Services
{
    public class CalculationService : ICalculationService
    {
        public decimal Calculate(CalculationModel calculation)
        {
            var strategy = CalculationStrategyFactory.GetStrategy(calculation.Operator);
            return strategy.Calculate(calculation.Operands);
        }
    }
}
