using FluentValidation;
using StudentMgmtSystem.Models.Request;

namespace StudentMgmtSystem.Validators
{
    public class CourseValidator : AbstractValidator<CourseRequest>
    {
    public CourseValidator()
        {
            RuleFor(x => x.CourseCode)
                .NotEmpty()
                .WithMessage("Course Code is required");
            RuleFor(x => x.Title)
               .NotEmpty()
               .WithMessage("Title is required");
        }
    }
}
