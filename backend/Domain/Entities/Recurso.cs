namespace Domain.Entities;

public partial class Recurso : BaseEntity
{
    public int IdProfesor { get; set; }

    public string NombreRecurso { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Asignacion> Asignacions { get; set; } = new List<Asignacion>();

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();

    public virtual Usuario IdProfesorNavigation { get; set; } = null!;
}
