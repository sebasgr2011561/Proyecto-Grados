using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class AsociacionRutaResponseDto
    {
        public int IdAsociacionRuta { get; set; }
        public int IdRuta { get; set; }
        public int IdRecurso { get; set; }
        public bool Estado { get; set; }
    }
}
