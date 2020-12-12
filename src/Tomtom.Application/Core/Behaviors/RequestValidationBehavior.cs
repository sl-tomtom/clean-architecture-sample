using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FluentValidation;

using MediatR;

using Tomtom.Application.Core.Pipeline;

namespace Tomtom.Application.Core.Behaviors
{
    public class RequestValidationBehavior<Q, R> : RequestPipelineBehavior<Q, R> where Q : Request<R>
    {
        private readonly IEnumerable<IValidator<Q>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<Q>> validators)
        {
            this._validators = validators;
        }

        public override Task<Result<R>> Handle(Q request, CancellationToken cancellationToken, RequestHandlerDelegate<Result<R>> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<Q>(request);

                var validationResults = _validators.Select(v => v.Validate(context));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                    return Task.FromResult(Result<R>.Failure(new ValidationException(failures)));
            }
            return next?.Invoke();
        }
    }

}
