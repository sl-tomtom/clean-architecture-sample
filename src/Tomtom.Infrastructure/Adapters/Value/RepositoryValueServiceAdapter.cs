using System.Threading.Tasks;

using Tomtom.Application.Core;
using Tomtom.Application.Exceptions;
using Tomtom.Domain.Value;
using Tomtom.Shared.Result;

namespace Tomtom.Infrastructure.Adapters.Value
{
    internal class RepositoryValueServiceAdapter : IValueService
    {
        private readonly IValueRepository _repository;

        public RepositoryValueServiceAdapter(IValueRepository repository)
        {
            this._repository = repository;
        }

        public Task<Result> AddValue(int id, string description)
        {
            return _repository.AddAsync(new ValueDto(id, description)).ContinueWith(before => before.IsCompletedSuccessfully ? Result.Success() : Result.Failure(before.Exception));
        }


        public Task<Result<ValueEntity>> GetValue(int id)
        {
            return _repository.GetAsync(id).ContinueWith(before => before.IsCompletedSuccessfully ? before.Result != null ? Result<ValueEntity>.Success(ValueEntity.Create(before.Result.Detail, before.Result.Id))
                                                                                                                          : Result<ValueEntity>.Failure(new NotFoundException(id, $"{nameof(GetValue)}({id}) has not found the resource"))
                                                                                                  : Result<ValueEntity>.Failure(before.Exception));
        }
    }
}
