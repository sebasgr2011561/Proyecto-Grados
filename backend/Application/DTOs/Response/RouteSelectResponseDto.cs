namespace Application.DTOs.Response
{
    public class RouteSelectResponseDto
    {
        public int IdRoute { get; set; }
        public int IdEstudiante { get; set; }
        public int IdRecurso { get; set; }
        public string? NombreRuta { get; set; }
        public bool Estado { get; set; }
    }
}
