using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
     public class ExperienceValidator:AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company name cannot be null!");
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Title cannot be null!");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Description cannot be null!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("You have to enter the date format for example October 2021 -December 2022");

        }
    }
}
