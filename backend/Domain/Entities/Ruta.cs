using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Ruta : BaseEntity
{
    public int IdEstudiante { get; set; }

    public int IdRecurso { get; set; }

    public bool Estado { get; set; }

    public virtual Usuario IdEstudianteNavigation { get; set; } = null!;

    public virtual Recurso IdRecursoNavigation { get; set; } = null!;
}
