using System;
using System.Threading;
using System.Threading.Tasks;

using Tomtom.Application.Core;

namespace Tomtom.Application.Value
{

    public class ValueQuery : Request<ValueViewModel>
    {
        public int Id { get; set; }
    }

    public class ValueRequestHandler : RequestHandler<ValueQuery, ValueViewModel>
    {
        private readonly IValueService _valueService;

        public ValueRequestHandler(IValueService valueService)
        {
            this._valueService = valueService;
        }

        public override Task<Result<ValueViewModel>> Handle(ValueQuery request, CancellationToken cancellationToken)
        {
            return _valueService.GetValue(request.Id).Map(value => new ValueViewModel(value.Id, value.Description));
        }
    }
}
