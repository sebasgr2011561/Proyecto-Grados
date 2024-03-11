using System;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;

namespace Infrastructure.Persistence.Repository
{
    public class PermitsRepository : GenericRepository<Permiso>, IPermitsRepository
    {
		public PermitsRepository(EDucaTdaContext context) : base(context) {	}
	}
}

