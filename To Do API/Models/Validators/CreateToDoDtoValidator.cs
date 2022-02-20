using FluentValidation;

namespace ToDoAPI.Models.Validators;

public class CreateTodoDtoValidator : AbstractValidator<CreateTodoDto>
{
    public CreateTodoDtoValidator()
    {
        RuleFor(d => d.Title)
            .NotEmpty();
        RuleFor(d => d.Description)
            .NotEmpty();
    }
}