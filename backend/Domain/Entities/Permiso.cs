using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Permiso : BaseEntity
{
    public int IdRol { get; set; }

    public string Permiso1 { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public virtual Role IdRolNavigation { get; set; } = null!;
}
