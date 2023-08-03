using FluentValidation;
using ForWorkProject.Models;

namespace ForWorkProject.Validators;

public class UpdateMessageValidator : AbstractValidator<UpdateMessageModel>
{
    public UpdateMessageValidator()
    {
        RuleFor(s => s.MessageText).NotEmpty();
    }
}
