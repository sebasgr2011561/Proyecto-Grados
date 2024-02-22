﻿namespace Domain.Entities;

public partial class Usuario : BaseEntity
{
    public int IdRol { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Asignacion> Asignacions { get; set; } = new List<Asignacion>();

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();

    public virtual Role IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Recurso> Recursos { get; set; } = new List<Recurso>();
}
