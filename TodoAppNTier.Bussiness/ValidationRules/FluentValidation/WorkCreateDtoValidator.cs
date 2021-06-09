using FluentValidation;
using System;
using TodoAppNTier.Dtos.WorkDtos;

namespace TodoAppNTier.Bussiness.ValidationRules.FluentValidation
{
    public class WorkCreateDtoValidator : AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Definition Açıklaması Boş Olamaz").Must(MustBeEmre); 
        }

        private bool MustBeEmre(string arg)
        {
            return arg != "Emre";
        }
    }
}
