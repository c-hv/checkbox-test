using Calculator.API.Models;

namespace Calculator.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OperationAttribute(string name, string symbol, string description, Operator @operator) : Attribute
    {
        public string Name { get; } = name;
        public string Symbol { get; } = symbol;
        public string Description { get; } = description;
        public Operator Operator { get; } = @operator;
    }
}
