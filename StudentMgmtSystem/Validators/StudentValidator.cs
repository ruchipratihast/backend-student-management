using FluentValidation;
using StudentMgmtSystem.Models.Request;

namespace StudentMgmtSystem.Validators
{
    public class StudentValidator : AbstractValidator<StudentRequest>
    {
        public StudentValidator()
        {
            RuleFor(x => x.FullName)
             .NotEmpty().WithMessage("Full name is required.");
            RuleFor(x => x.Email)
             .NotEmpty().WithMessage("Email is required.");
            RuleFor(x => x.Birthday)
             .NotEmpty().WithMessage("Birthday is required.");
            RuleFor(x => x.CourseId)
             .NotEmpty().WithMessage("Course Id is required.")
             .NotEqual(Guid.Empty).WithMessage("A valid Course Id must be provided.");
        }
    }
}
