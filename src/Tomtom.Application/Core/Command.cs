
using MediatR;

using Tomtom.Shared.Result;

namespace Tomtom.Application.Core
{

    public abstract class Command : IRequest<Result>
    {

    }
}
