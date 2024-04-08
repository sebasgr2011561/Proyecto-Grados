using System;
using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Infrastructure.Persistence.Interfaces
{
	public interface ICategoryRepository : IGenericRepository<Categorium>
	{
        Task<BaseEntityResponse<Categorium>> ListCategories(BaseFiltersRequest request);
    }
}

