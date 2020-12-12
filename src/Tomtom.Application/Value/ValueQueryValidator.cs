using System;
using System.Collections.Generic;
using System.Text;

using FluentValidation;

namespace Tomtom.Application.Value
{
    public class ValueQueryValidator : AbstractValidator<ValueQuery>
    {
        public ValueQueryValidator()
        {

            RuleFor(query => query.Id).Must(id => id > 0);
        }
    }
}
