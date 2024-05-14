using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Contexts.New;

public partial class Ruta
{
    public int IdRuta { get; set; }

    public int IdEstudiante { get; set; }

    public int IdRecurso { get; set; }

    public bool Estado { get; set; }

    public virtual Usuario IdEstudianteNavigation { get; set; } = null!;

    public virtual Recurso IdRecursoNavigation { get; set; } = null!;
}
