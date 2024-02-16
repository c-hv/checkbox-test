namespace Calculator.API.Models
{
    public class AvailableOperation(
        string name,
        string description,
        string symbol,
        Operator @operator)
    {
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public string Symbol { get; set; } = symbol;
        public Operator Operator { get; set; } = @operator;
    }
}
