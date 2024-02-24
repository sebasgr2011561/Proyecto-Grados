namespace Application.DTOs.Request
{
    public class CourseRequestDto
    {
        public int IdRecurso { get; set; }
        public int IdProfesor { get; set; }
        public string NombreRecurso { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
    }
}
