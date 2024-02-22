using Application.DTOs.Request;
using FluentValidation;

namespace Application.Validators.User
{
    public class UserValidator : AbstractValidator<UserRequestDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.IdRol)
                .NotNull().WithMessage("El campo IdRol no puede ser nulo.")
                .NotEmpty().WithMessage("El campo IdRol no puede estar vacio.");

            RuleFor(x => x.Nombres)
                .NotNull().WithMessage("El campo Nombres no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombres no puede estar vacio.");

            RuleFor(x => x.Apellidos)
                .NotNull().WithMessage("El campo Apellidos no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Apellidos no puede estar vacio.");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("El campo Email no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Email no puede estar vacio.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("El campo Password no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Password no puede estar vacio.");
        }
    }
}
