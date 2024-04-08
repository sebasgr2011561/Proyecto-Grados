using Application.DTOs.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Category
{
    public class CategoryValidator : AbstractValidator<CategoryRequestDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.NombreCategoria)
                .NotNull().WithMessage("El campo NombreCategoria no puede ser nulo.")
                .NotEmpty().WithMessage("El campo NombreCategoria no puede estar vacio.");
        }
    }
}
