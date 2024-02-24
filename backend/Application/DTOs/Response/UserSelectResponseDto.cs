namespace Application.DTOs.Response
{
    public class UserSelectResponseDto
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
    }
}
