using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

using Tomtom.Infrastructure.Core.Persistance;

namespace Tomtom.Infrastructure.Adapters.Value
{

    internal interface IValueRepository : IRepository<ValueDto>
    {
    }


    internal class MemoryValueRepository : IValueRepository
    {
        private readonly ConcurrentDictionary<int, ValueDto> _concurrentDictionaries;

        public MemoryValueRepository()
        {
            _concurrentDictionaries = new ConcurrentDictionary<int, ValueDto>();
            _concurrentDictionaries.TryAdd(1, new ValueDto(1, "value 1"));
        }

        public Task AddAsync(ValueDto id)
        {
            if (id.Id == 0) Task.FromException(new ArgumentOutOfRangeException(nameof(id)));
            Task task;
            try
            {
                _concurrentDictionaries.AddOrUpdate(id.Id, id, (id, value) => value);
            }
            catch (ArgumentNullException anex)
            {
                task = Task.FromException(anex);
            }
            catch (OverflowException anex)
            {
                task = Task.FromException(anex);
            }
            finally
            {
                task = Task.CompletedTask;
            }
            return task;
        }

        public Task<ValueDto> GetAsync(int id)
        {
            if (id == 0) return Task.FromException<ValueDto>(new ArgumentOutOfRangeException(nameof(id)));
            _concurrentDictionaries.TryGetValue(id, out ValueDto value);
            return Task.FromResult(value);
        }
    }
}