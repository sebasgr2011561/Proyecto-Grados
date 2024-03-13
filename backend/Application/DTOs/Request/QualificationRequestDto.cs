namespace Application.DTOs.Request
{
    public class QualificationRequestDto
    {
        public int IdCalificacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdRecurso { get; set; }
        public int Calificacion { get; set; }
        public string? Comentario { get; set; }
        public bool Estado { get; set; } = false;
    }
}
