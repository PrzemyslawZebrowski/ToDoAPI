using FluentValidation;

namespace ToDoAPI.Models.Validators;

public class CreateToDoDtoValidator : AbstractValidator<CreateToDoDto>
{
    public CreateToDoDtoValidator()
    {
        RuleFor(d => d.Title)
            .NotEmpty();
        RuleFor(d => d.Description)
            .NotEmpty();
    }
}