
using FluentValidation;
using ForWorkProject.Models;

namespace ForWorkProject.Validators;

public class CreateChatValidator: AbstractValidator<CreateChatModel>
{
    public CreateChatValidator()
    {
        RuleFor(s => s.Name).NotNull().MaximumLength(50);
        RuleFor(s => s.Description).MaximumLength(50);
    }
}
