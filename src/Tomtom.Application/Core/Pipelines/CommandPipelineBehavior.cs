
using System.Threading;
using System.Threading.Tasks;

using MediatR;

namespace Tomtom.Application.Core.Pipeline
{
    public abstract class CommandPipelineBehavior<Q> : IPipelineBehavior<Q, Result> where Q : IRequest<Result>
    {
        public abstract Task<Result> Handle(Q request, CancellationToken cancellationToken, RequestHandlerDelegate<Result> next);
    }
}
