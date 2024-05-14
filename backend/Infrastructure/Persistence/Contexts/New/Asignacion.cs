using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Contexts.New;

public partial class Asignacion
{
    public int IdAsignacion { get; set; }

    public int IdEstudiante { get; set; }

    public int IdRecurso { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public bool Estado { get; set; }

    public virtual Usuario IdEstudianteNavigation { get; set; } = null!;

    public virtual Recurso IdRecursoNavigation { get; set; } = null!;
}
