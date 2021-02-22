using F1Encyclopedia.Core.Queries;
using F1Encyclopedia.Data.Models.Drivers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Validators.Drivers
{
    public class GetDriversSnapshotValidator : AbstractValidator<GetDriversSnapshot>
    {
        public GetDriversSnapshotValidator()
        {
            RuleFor(x => x.Drivers).Must(x => x.Count() < 10);
        }
    }
}

