namespace Calculator.API.Models
{
    public class AvailableOperation(
        string name,
        string description,
        string symbol,
        int maxOperands)
    {
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public string Symbol { get; set; } = symbol;
        public int MaxOperands { get; set; } = maxOperands;
    }
}
