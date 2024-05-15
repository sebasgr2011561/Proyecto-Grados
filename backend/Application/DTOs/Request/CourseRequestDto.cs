using Microsoft.AspNetCore.Http;

namespace Application.DTOs.Request
{
    public class CourseRequestDto
    {
        public int IdProfesor { get; set; }
        public int IdCategoria { get; set; }
        public string NombreRecurso { get; set; } = null!;
        public IFormFile ImagenRecurso { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Duracion { get; set; }
        public int Precio { get; set; }
    }
}
