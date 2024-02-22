using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class UserSelectResponseDto
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
    }
}
