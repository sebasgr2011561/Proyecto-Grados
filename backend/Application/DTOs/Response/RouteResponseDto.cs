namespace Application.DTOs.Response
{
    public class RouteResponseDto
    {
        public int IdRoute { get; set; }
        public int IdEstudiante { get; set; }
        public string? NombreRuta { get; set; }
        public bool Estado { get; set; }
    }
}
