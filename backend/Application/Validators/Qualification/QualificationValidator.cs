using Application.DTOs.Request;
using FluentValidation;

namespace Application.Validators.Qualification
{
    public class QualificationValidator : AbstractValidator<QualificationRequestDto>
    {
        public QualificationValidator()
        {
            RuleFor(x => x.IdUsuario)
                .NotNull().WithMessage("El campo IdUduario no puede ser nulo.")
                .NotEmpty().WithMessage("El campo IdUduario no puede estar vacio.");

            RuleFor(x => x.IdRecurso)
                .NotNull().WithMessage("El campo IdRecurso no puede ser nulo.")
                .NotEmpty().WithMessage("El campo IdRecurso no puede estar vacio.");

            RuleFor(x => x.Calificacion)
                .NotNull().WithMessage("El campo Calificacion no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Calificacion no puede estar vacio.");

            RuleFor(x => x.Comentario)
                .NotNull().WithMessage("El campo Comentaerio no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Comentaerio no puede estar vacio.");
        }
    }
}
