
using System.Threading;
using System.Threading.Tasks;

using MediatR;

namespace Tomtom.Application.Core
{
    public abstract class CommandHandler<Q> : IRequestHandler<Q, Result> where Q : Command
    {
        public abstract Task<Result> Handle(Q request, CancellationToken cancellationToken);
    }

    
}
