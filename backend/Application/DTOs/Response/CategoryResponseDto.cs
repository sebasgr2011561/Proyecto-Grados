using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class CategoryResponseDto
    {
        public int IdCategoria { get; set; }
        public string? NombreCategoria { get; set; }
        public bool Estado { get; set; }
    }
}
