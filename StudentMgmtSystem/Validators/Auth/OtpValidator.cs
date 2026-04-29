using FluentValidation;
using StudentMgmtSystem.Models.Request.Auth;

namespace StudentMgmtSystem.Validators.Auth
{
    public class OtpValidator : AbstractValidator<OtpRequest>
    {
        public OtpValidator() 
        { 
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
