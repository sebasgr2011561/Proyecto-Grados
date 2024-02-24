namespace Application.DTOs.Request
{
    public class UserRequestDto
    {
        public int IdUsuario { get; set; } = 0;
        public int IdRol { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
