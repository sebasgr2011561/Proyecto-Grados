namespace Domain.Entities;

public partial class Calificacione : BaseEntity
{
    public int IdUsuario { get; set; }

    public int IdRecurso { get; set; }

    public int? Calificacion { get; set; }

    public string? Comentario { get; set; }

    public virtual Recurso IdRecursoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
