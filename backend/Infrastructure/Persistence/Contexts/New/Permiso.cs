using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Contexts.New;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public int IdRol { get; set; }

    public string Permiso1 { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public virtual Role IdRolNavigation { get; set; } = null!;
}
