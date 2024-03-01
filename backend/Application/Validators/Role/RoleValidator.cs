using Application.DTOs.Request;
using FluentValidation;

namespace Application.Validators.Role
{
    public class RoleValidator : AbstractValidator<RoleRequestDto>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Descripcion)
                .NotNull().WithMessage("El campo Descripción no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Descripción no puede estar vacio.");
        }
    }
}
