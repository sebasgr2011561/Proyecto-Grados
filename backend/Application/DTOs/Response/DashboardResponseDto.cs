using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class DashboardResponseDto
    {
        public int IdDashboard { get; set; }
        public int EstudiantesRegistrados { get; set; }
        public string? NombreRecurso { get; set; }
        public bool? Estado { get; set; }
    }
}
