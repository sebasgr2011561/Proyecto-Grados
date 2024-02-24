using Application.DTOs.Request;
using FluentValidation;

namespace Application.Validators.Course
{
    public class CourseValidator : AbstractValidator<CourseRequestDto>
    {
        public CourseValidator()
        {
            RuleFor(x => x.IdProfesor)
                .NotNull().WithMessage("El campo IdProfesor no puede ser nulo.")
                .NotEmpty().WithMessage("El campo IdProfesor no puede estar vacio.");

            RuleFor(x => x.NombreRecurso)
                .NotNull().WithMessage("El campo NombreRecurso no puede ser nulo.")
                .NotEmpty().WithMessage("El campo NombreRecurso no puede estar vacio.");
        }
    }
}
