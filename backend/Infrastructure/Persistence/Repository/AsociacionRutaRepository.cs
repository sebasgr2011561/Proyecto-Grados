using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using System;
namespace Infrastructure.Persistence.Repository
{
	public class AsociacionRutaRepository : GenericRepository<AsociacionRuta>, IAsociacionRutaRepository
    {
		public AsociacionRutaRepository(EDucaTdaContext context) : base(context) { }
}
}

