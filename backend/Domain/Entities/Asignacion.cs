using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Asignacion : BaseEntity
{
    public int IdEstudiante { get; set; }

    public int IdRecurso { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public virtual Usuario IdEstudianteNavigation { get; set; } = null!;

    public virtual Recurso IdRecursoNavigation { get; set; } = null!;
}
