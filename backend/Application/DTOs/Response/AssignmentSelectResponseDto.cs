using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class AssignmentSelectResponseDto
    {
        public int IdAsignacion { get; set; }
        public string? NombreRecurso { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public bool Estado { get; set; }
    }
}
