using FluentValidation;
using WebJerseyGoal.Models.Category;

namespace WebJerseyGoal.Models.Validators.Category
{
    public class CategoryCreateValidator: AbstractValidator<CategoryCreateViewModel>
    {
        public CategoryCreateValidator() {

            RuleFor(x => x.Name)
                  .NotEmpty()
                 .WithMessage("Назва є обов'язковою")
                 .MaximumLength(250)
                 .WithMessage("Назва повинна містити не більше 250 символів");
            RuleFor(x => x.Slug)
                .NotEmpty()
                .WithMessage("Слаг є обов'язковим")
                .MaximumLength(250)
                .WithMessage("Слаг повинен містити не більше 250 символів");
            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage("Файл зображення є обов'язковим");     
    }


    }
}
