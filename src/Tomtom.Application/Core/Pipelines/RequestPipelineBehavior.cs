
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Tomtom.Shared.Result;

namespace Tomtom.Application.Core.Pipeline
{

    public abstract class RequestPipelineBehavior<Q, R> : IPipelineBehavior<Q, Result<R>> where Q : IRequest<Result<R>>
    {
        public abstract Task<Result<R>> Handle(Q request, CancellationToken cancellationToken, RequestHandlerDelegate<Result<R>> next);
    }
}
