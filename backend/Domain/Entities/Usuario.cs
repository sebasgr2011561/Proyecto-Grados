using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Usuario : BaseEntity
{
    public int IdRol { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Celular { get; set; }

    public string? Biografia { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Imagen { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Asignacion> Asignacions { get; set; } = new List<Asignacion>();

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();

    public virtual Role IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Recurso> Recursos { get; set; } = new List<Recurso>();

    public virtual ICollection<Ruta> Ruta { get; set; } = new List<Ruta>();
}
