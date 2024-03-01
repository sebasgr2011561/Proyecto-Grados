using Application.DTOs.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Assignments
{
    public class AssignmentValidator : AbstractValidator<AssignmentRequestDto>
    {
        public AssignmentValidator()
        {
            RuleFor(x => x.IdEstudiante)
                .NotNull().WithMessage("El campo IdEstudiante no puede ser nulo.")
                .NotEmpty().WithMessage("El campo IdEstudiante no puede estar vacio.");

            RuleFor(x => x.IdRecurso)
                .NotNull().WithMessage("El campo IdCurso no puede ser nulo.")
                .NotEmpty().WithMessage("El campo IdCurso no puede estar vacio.");
        }
    }
}
