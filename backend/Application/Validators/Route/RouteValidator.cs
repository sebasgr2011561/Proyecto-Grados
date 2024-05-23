using Application.DTOs.Request;
using FluentValidation;

namespace Application.Validators.Route
{
    public class RouteValidator : AbstractValidator<RouteRequestDto>
    {
        public RouteValidator()
        {
            RuleFor(x => x.IdEstudiante)
                .NotNull().WithMessage("El campo Estudiante no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Estudiante no puede estar vacio.");
        }
    }
}
