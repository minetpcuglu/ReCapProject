using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public  class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {

                RuleFor(x => x.DailyPrice).NotEmpty().WithMessage("Boş geçilemez");
                RuleFor(x => x.DailyPrice).GreaterThan(0).WithMessage("Lütfen 0 dan farklı bir değer giriniz");
                RuleFor(x => x.ModelYear).NotEmpty().WithMessage("Boş geçilemez");
                RuleFor(x => x.Description).NotEmpty().WithMessage("Boş geçilemez");

        }
    }
}
