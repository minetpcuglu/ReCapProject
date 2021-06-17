using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(x => x.RentDate).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.ReturnDate).NotEmpty().WithMessage("Boş Geçilemez");
          
        }
    }
}
