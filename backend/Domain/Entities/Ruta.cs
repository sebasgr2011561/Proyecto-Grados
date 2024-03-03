namespace Domain.Entities
{
    public class Ruta : BaseEntity
    {
        public int IdEstudiante { get; set; }
        public int IdRecurso { get; set; }
        public virtual Usuario IdEstudianteNavigation { get; set; } = null!;
        public virtual Recurso IdRecursoNavigation { get; set; } = null!;
    }
}
