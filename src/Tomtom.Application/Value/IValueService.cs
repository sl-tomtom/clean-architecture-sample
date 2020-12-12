using System.Threading.Tasks;

using Tomtom.Application.Core;

namespace Tomtom.Application.Value
{
    
    public interface IValueService
    {
        Task<Result<Domain.Value.Value>> GetValue(int id);
        Task<Result> AddValue(int id, string description);
    }
}