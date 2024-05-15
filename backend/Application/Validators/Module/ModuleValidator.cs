using Application.DTOs.Request;
using FluentValidation;

namespace Application.Validators.Module
{
    public class ModuleValidator : AbstractValidator<ModuleRequestDto>
    {
        public ModuleValidator()
        {
            RuleFor(x => x.IdRecurso)
                .NotNull().WithMessage("El campo IdRecurso no puede ser nulo.")
                .NotEmpty().WithMessage("El campo IdRecurso no puede estar vacio.");

            RuleFor(x => x.NombreModulo)
                .NotNull().WithMessage("El campo NombreModulo no puede ser nulo.")
                .NotEmpty().WithMessage("El campo NombreModulo no puede estar vacio.");
        }
    }
}
