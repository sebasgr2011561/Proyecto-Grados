using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Contexts.New;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public string? ImagenCategoria { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Recurso> Recursos { get; set; } = new List<Recurso>();
}
