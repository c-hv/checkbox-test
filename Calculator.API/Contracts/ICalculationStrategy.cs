namespace Calculator.API.Contracts
{
    public interface ICalculationStrategy
    {
        decimal Calculate(decimal[] operands);
    }
}
