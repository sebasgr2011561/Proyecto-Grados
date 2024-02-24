namespace Application.DTOs.Response
{
    public class CourseSelectResponseDto
    {
        public int IdRecurso { get; set; }
        public int IdProfesor { get; set; }
        public string NombreRecurso { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
    }
}
