using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CertficateValidator : AbstractValidator<Certficate>
    {
        public CertficateValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company name cannot be null!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be null!");
            RuleFor(x => x.Links).NotEmpty().WithMessage("Links cannot be null!");

        }
    }
}
