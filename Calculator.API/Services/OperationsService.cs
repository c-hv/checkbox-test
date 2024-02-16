using System.Reflection;
using Calculator.API.Attributes;
using Calculator.API.Contracts;
using Calculator.API.Models;

namespace Calculator.API.Services
{
    public class OperationsService : IOperationsService
    {
        public IEnumerable<AvailableOperation> GetAvailableOperations()
        {
            var operationTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(ICalculationStrategy).IsAssignableFrom(type) && type is { IsInterface: false, IsAbstract: false })
                .Where(type => Attribute.IsDefined(type, typeof(OperationAttribute)));

            foreach (var type in operationTypes)
            {
                var attribute = type.GetCustomAttribute<OperationAttribute>();
                if (attribute != null)
                {
                    yield return new AvailableOperation(attribute.Name, attribute.Description, attribute.Symbol,
                        attribute.Operator);
                }
            }
        }
    }
}
