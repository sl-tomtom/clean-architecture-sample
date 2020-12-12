
using System.Threading;
using System.Threading.Tasks;

using MediatR;

namespace Tomtom.Application.Core
{
    public abstract class RequestHandler<Q, R> : IRequestHandler<Q, Result<R>> where Q : Request<R>
    {
        public abstract Task<Result<R>> Handle(Q request, CancellationToken cancellationToken);
    }

    
}
