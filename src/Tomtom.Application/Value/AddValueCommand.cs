
using System.Threading;
using System.Threading.Tasks;

using Tomtom.Application.Core;
using Tomtom.Domain.Value;
using Tomtom.Shared.Result;

namespace Tomtom.Application.Value
{
    public class AddValueCommand : Command
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class AddValueCommandHandler : CommandHandler<AddValueCommand>
    {
        private readonly IValueService _valueService;

        public AddValueCommandHandler(IValueService valueService)
        {
            this._valueService = valueService;
        }

        public override Task<Result> Handle(AddValueCommand request, CancellationToken cancellationToken)
        {
            return _valueService.AddValue(request.Id, request.Description);
        }
    }
}
