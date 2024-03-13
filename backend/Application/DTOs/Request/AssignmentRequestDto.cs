namespace Application.DTOs.Request
{
    public class AssignmentRequestDto
    {
        public int IdEstudiante { get; set; }
        public int IdRecurso { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}
