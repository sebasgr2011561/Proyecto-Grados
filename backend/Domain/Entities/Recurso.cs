﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Recurso : BaseEntity
{
    public int IdProfesor { get; set; }

    public string NombreRecurso { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? ImagenPortada { get; set; }
    
    public int? Duracion { get; set; }
    
    public double? Precio { get; set; }

    public int? IdCategoria { get; set; }

    public virtual ICollection<Asignacion> Asignacions { get; set; } = new List<Asignacion>();

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();

    public virtual Categorium? IdCategoriaNavigation { get; set; }

    public virtual Usuario IdProfesorNavigation { get; set; } = null!;

    public virtual ICollection<Modulo> Modulos { get; set; } = new List<Modulo>();

}
