using Calculator.API.Models;

namespace Calculator.API.Contracts
{
    public interface ICalculationService
    {
        decimal Calculate(CalculationModel calculation);
    }
}
