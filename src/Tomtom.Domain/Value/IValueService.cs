namespace Tomtom.Domain.Value
{
    using System.Threading.Tasks;
    using Tomtom.Shared.Result;

    public interface IValueService
    {
        Task<Result<ValueEntity>> GetValue(int id);
        Task<Result> AddValue(int id, string description);
    }
}