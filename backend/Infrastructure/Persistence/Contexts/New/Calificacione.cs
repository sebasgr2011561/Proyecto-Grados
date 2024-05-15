using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Contexts.New;

public partial class Calificacione
{
    public int IdRecurso { get; set; }

    public int IdUsuario { get; set; }

    public int IdRecurso1 { get; set; }

    public int? Calificacion { get; set; }

    public string? Comentario { get; set; }

    public bool Estado { get; set; }

    public virtual Recurso IdRecurso1Navigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
