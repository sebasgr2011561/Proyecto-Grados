using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class RoleResponseDto
    {
        public int IdRol { get; set; }
        public string Descripcion { get; set; } = null!;
    }
}
