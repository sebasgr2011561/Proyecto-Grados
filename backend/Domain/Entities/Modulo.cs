using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Modulo : BaseEntity
{
    public int IdRecurso { get; set; }

    public string NombreModulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Urlmodulo { get; set; } = null!;

    public virtual Recurso? IdRecursoNavigation { get; set; } = null!;
}
