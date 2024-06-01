using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Ruta : BaseEntity
{
    public int IdEstudiante { get; set; }

    public string? NombreRuta { get; set; }

    public virtual Usuario IdEstudianteNavigation { get; set; } = null!;

    public virtual ICollection<AsociacionRuta> AsociacionRutas { get; set; } = new List<AsociacionRuta>();
}
