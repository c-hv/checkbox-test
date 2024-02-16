namespace Calculator.API.Models
{
    public record CalculationModel(decimal[] Operands, Operator Operator);
}
