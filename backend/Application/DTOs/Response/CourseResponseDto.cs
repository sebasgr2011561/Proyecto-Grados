namespace Application.DTOs.Response
{
    public class CourseResponseDto
    {
        public int IdRecurso { get; set; }
        public int IdProfesor { get; set; }
        public string NombreRecurso { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
