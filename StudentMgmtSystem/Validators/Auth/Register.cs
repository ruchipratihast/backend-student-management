using FluentValidation;
using StudentMgmtSystem.Models.Request.Auth;

namespace StudentMgmtSystem.Validators.Auth
{
    public class Register : AbstractValidator<RegisterRequest>
    {
        public Register() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required.")
                .Must(role => role == "Student" || role == "Teacher" || role == "Admin")
                .WithMessage("Role must be either 'Student', 'Teacher', or 'Admin'.");
            RuleFor(x => x.Otp)
                .NotEmpty().WithMessage("OTP is required.")
                .Length(6).WithMessage("OTP must be 6 characters long.");
        }
    }
}
