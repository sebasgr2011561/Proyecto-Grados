namespace Application.DTOs.Response
{
    public class AssignmentSelectResponseDto
    {
        public int IdAsignacion { get; set; }
        public int IdEstudiante { get; set; }
        public int IdRecurso { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public bool Estado { get; set; }
    }
}
