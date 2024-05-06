namespace Application.DTOs.Response
{
    public class AssignmentResponseDto
    {
        public string? NombreRecurso { get; set; }
        public string? Descripcion { get; set; }
        public string? ImagenPortada { get; set; }
        public int? Duracion { get; set; }
        public double? Precio { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}
