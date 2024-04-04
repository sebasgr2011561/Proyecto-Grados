using System;
using System.Collections.Generic;
namespace Domain.Entities;

public partial class Categorium : BaseEntity
{
    public string? NombreCategoria { get; set; }

    public virtual ICollection<Recurso> Recursos { get; set; } = new List<Recurso>();
}
