using System;
namespace Domain.Entities
{
    public class AsociacionRuta : BaseEntity
	{
		public int IdRuta { get; set; }
        public int IdRecurso { get; set; }

        public virtual Ruta IdRutaNavigation { get; set; } = null!;

        public virtual Recurso IdRecursoNavigation { get; set; } = null!;
    }
}

