using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Boş Geçilemez");

          
        }
    }
}
