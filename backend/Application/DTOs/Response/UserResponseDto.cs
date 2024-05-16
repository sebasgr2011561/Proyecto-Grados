namespace Application.DTOs.Response
{
    public class UserResponseDto
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Imagen { get; set; }
        public string Biografia { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
