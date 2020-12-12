
using FluentValidation;

namespace Tomtom.Application.Value
{
    public class AddValueCommandValidator : AbstractValidator<ValueQuery>
    {
        public AddValueCommandValidator()
        {

            RuleFor(query => query.Id).Must(id => id > 0);
        }
    }
}
