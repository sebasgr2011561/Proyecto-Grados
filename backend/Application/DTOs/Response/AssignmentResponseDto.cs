namespace Application.DTOs.Response
{
    public class AssignmentResponseDto
    {
        public int IdAsignacion { get; set; }
        public string? NombreRecurso { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaAsignacion { get; set; }
    }
}
