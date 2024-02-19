using Calculator.API.Models;

namespace Calculator.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OperationAttribute() : Attribute
    {
        public OperationAttribute(string name, string symbol, string description, int maxOperands = 100) : this()
        {
            Name = name;
            Symbol = symbol;
            Description = description;
            MaxOperands = maxOperands;
        }

        public string Name { get; }
        public string Symbol { get; }
        public string Description { get; }
        public int MaxOperands { get; }
    }
}
