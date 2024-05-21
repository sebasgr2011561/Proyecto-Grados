namespace Application.DTOs.Response
{
    public class AssignmentSelectResponseDto
    {
        public int IdAsignacion { get; set; }
        public int IdRecurso { get; set; }
        public string? ImagenPortada { get; set; }
        public string? NombreRecurso { get; set; }
        public string? Descripcion { get; set; }
        public int? Duracion { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}
