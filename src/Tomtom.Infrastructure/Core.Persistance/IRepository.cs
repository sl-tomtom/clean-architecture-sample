using System.Threading.Tasks;

namespace Tomtom.Infrastructure.Core.Persistance
{
    internal interface IRepository<T> 
    {
        Task<T> GetAsync(int id);
        Task AddAsync(T id);

    }
}