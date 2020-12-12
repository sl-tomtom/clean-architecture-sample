using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Tomtom.Application.Core;
using Tomtom.Application.Value;
using Tomtom.Application.Exceptions;


namespace Tomtom.Infrastructure.Adapters.Value
{
    using Value = Domain.Value.Value;
    internal class ValueServiceAdapter : IValueService
    {
        private readonly IValueRepository _repository;

        public ValueServiceAdapter(IValueRepository repository)
        {
            this._repository = repository;
        }

        public Task<Result> AddValue(int id, string description)
        {
            return _repository.AddAsync(new ValueDto(id, description)).ContinueWith(before => before.IsCompletedSuccessfully ? Result.Success() : Result.Failure(before.Exception));
        }


        public Task<Result<Value>> GetValue(int id)
        {                                                                                                         
            return _repository.GetAsync(id).ContinueWith(before => before.IsCompletedSuccessfully ? before.Result != null ? Result<Value>.Success(Value.Create(before.Result.Detail, before.Result.Id)) 
                                                                                                                          : Result<Value>.Failure(new NotFoundException(id, $"{nameof(GetValue)}({id}) has not found the resource"))
                                                                                                  : Result<Value>.Failure(before.Exception));
        }
    }
}
