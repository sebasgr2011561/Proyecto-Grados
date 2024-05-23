﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request
{
    public class ModuleRequestDto
    {
        public int IdModulo { get; set; }
        public int IdRecurso { get; set; }
        public string? NombreModulo { get; set; }
        public string? Descripcion { get; set;}
        public string? URLModulo { get; set;}
    }
}
