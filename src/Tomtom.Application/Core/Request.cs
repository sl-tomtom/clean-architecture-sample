
using MediatR;

using Tomtom.Shared.Result;

namespace Tomtom.Application.Core
{
    public abstract class Request<R> : IRequest<Result<R>>
    {

    }
}
