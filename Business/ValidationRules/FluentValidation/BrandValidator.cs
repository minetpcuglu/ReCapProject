using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.BrandName).MinimumLength(2).WithMessage("En az iki karakter olmalıdır");
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("Boş geçilemez");

            //olmayan bir kuralı kendimiz yazmak istersek 
            RuleFor(x => x.BrandName).Must(StartWithA).WithMessage("Marka A harfi ile başlamalıdır ");  //marka ismi A ile baslamalı
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A"); //false olursa kural patlar  
        }
    }
}
