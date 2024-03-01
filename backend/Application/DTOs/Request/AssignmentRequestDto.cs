using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request
{
    public class AssignmentRequestDto
    {
        public int IdEstudiante { get; set; }
        public int IdRecurso { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}
