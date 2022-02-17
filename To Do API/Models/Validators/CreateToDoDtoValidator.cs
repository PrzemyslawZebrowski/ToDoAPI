using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ToDoAPI.Models.Validators
{
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
}
