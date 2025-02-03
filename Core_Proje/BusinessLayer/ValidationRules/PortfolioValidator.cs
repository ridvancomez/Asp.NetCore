using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(value => value.Name).NotEmpty().WithMessage("Ad alanı boş geçilemezsdsa");
            RuleFor(value => value.Name).MinimumLength(3).WithMessage("Ad alanı en az 3 karakter olmalıdır");
            RuleFor(value => value.ImageUrl).NotEmpty().WithMessage("Resim alanı boş geçilemez");
            RuleFor(value => value.ProjectUrl).NotEmpty().WithMessage("Proje Url alanı boş geçilemez");
            RuleFor(value => value.ImageUrl2).NotEmpty().WithMessage("Resim 2 alanı boş geçilemez");

        }
    }
}
