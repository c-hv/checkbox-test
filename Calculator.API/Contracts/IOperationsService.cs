using Calculator.API.Models;

namespace Calculator.API.Contracts
{
    public interface IOperationsService
    {
        IEnumerable<AvailableOperation> GetAvailableOperations();
    }
}
