using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Contexts.New;

public partial class Recurso
{
    public int IdRecurso { get; set; }

    public int IdProfesor { get; set; }

    public int IdCategoria { get; set; }

    public string NombreRecurso { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? ImagenPortada { get; set; }

    public int? Duracion { get; set; }

    public double? Precio { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Asignacion> Asignacions { get; set; } = new List<Asignacion>();

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();

    public virtual Categorium IdCategoriaNavigation { get; set; } = null!;

    public virtual Usuario IdProfesorNavigation { get; set; } = null!;

    public virtual ICollection<Modulo> Modulos { get; set; } = new List<Modulo>();

    public virtual ICollection<Ruta> Ruta { get; set; } = new List<Ruta>();
}
