
using MediatR;

namespace Tomtom.Application.Core
{
    public abstract class Request<R> : IRequest<Result<R>>
    {

    }
}
