using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FluentValidation;

using MediatR;

using Tomtom.Application.Core.Pipeline;

namespace Tomtom.Application.Core.Behaviors
{
    public class CommandValidationBehavior<C> : CommandPipelineBehavior<C> where C : Command
    {
        private readonly IEnumerable<IValidator<C>> _validators;

        public CommandValidationBehavior(IEnumerable<IValidator<C>> validators)
        {
            this._validators = validators;
        }

        public async override Task<Result> Handle(C request, CancellationToken cancellationToken, RequestHandlerDelegate<Result> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<C>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                    return Result.Failure(new ValidationException(failures));
            }
            return await next?.Invoke();
        }
    }

}
