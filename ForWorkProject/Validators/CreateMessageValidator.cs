using FluentValidation;
using ForWorkProject.Models;

namespace ForWorkProject.Validators;

public class CreateMessageValidator : AbstractValidator<CreateMessageModel>
{
    public CreateMessageValidator() 
    { 
        RuleFor(s => s.MessageText).NotEmpty().MaximumLength(100);
    }
}
