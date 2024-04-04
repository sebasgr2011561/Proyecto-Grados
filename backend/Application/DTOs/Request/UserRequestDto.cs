namespace Application.DTOs.Request
{
    public class UserRequestDto
    {
        public int IdRol { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Celular { get; set; }
        public string? Biografia { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Imagen { get; set; }
        public bool Estado { get; set; }
    }
}
