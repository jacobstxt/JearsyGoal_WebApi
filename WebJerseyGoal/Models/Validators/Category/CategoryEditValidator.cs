using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebJerseyGoal.DataBase;
using WebJerseyGoal.Models.Category;

namespace WebJerseyGoal.Models.Validators.Category
{
    public class CategoryEditValidator: AbstractValidator<CategoryEditViewModel>
    {
        public CategoryEditValidator(AppDbJerseyGoalContext db) {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Назва є обов'язковою")
                .Must(name => !string.IsNullOrEmpty(name))
                .WithMessage("Назва не може бути порожньою або null")
                .MaximumLength(250)
                .WithMessage("Назва повинна містити не більше 250 символів");
            RuleFor(x => x.Slug)
                .NotEmpty()
                .WithMessage("Слаг є обов'язковим")
                .MaximumLength(250)
                .WithMessage("Слаг повинен містити не більше 250 символів");
        }


    }
}
