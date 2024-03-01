namespace Domain.Entities;

public partial class Role : BaseEntity
{
    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
