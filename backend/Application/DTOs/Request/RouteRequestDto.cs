namespace Application.DTOs.Request
{
    public class RouteRequestDto
    {
        public int IdRoute { get; set; }
        public int IdEstudiante { get; set; }
        public string? NombreRuta { get; set; }
        public bool Estado { get; set; }
    }
}
