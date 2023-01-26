using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SpeakerValidator : AbstractValidator<Speaker>
    {
        public SpeakerValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be null!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject cannot be null!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("You have to enter the date format for example Oct 12, 2023");
        }
    }
}
