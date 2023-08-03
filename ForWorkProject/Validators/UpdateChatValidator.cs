using FluentValidation;
using ForWorkProject.Models;

namespace ForWorkProject.Validators;

public class UpdateChatValidator : AbstractValidator<UpdateChatModel>
{
    public UpdateChatValidator()
    {
        RuleFor(s => s.Name).MaximumLength(50);
        RuleFor(s => s.Description).MaximumLength(50);
    }
}
