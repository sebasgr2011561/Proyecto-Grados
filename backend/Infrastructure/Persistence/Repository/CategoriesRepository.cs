using System;
using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
	public class CategoriesRepository : GenericRepository<Categorium>, ICategoryRepository
    {
        public CategoriesRepository(EDucaTdaContext context) : base(context) { }

        public async Task<BaseEntityResponse<Categorium>> ListCategories(BaseFiltersRequest request)
        {
            var response = new BaseEntityResponse<Categorium>();
            var categories = GetEntityQuery();

            if (request.NumFilter is not null && !string.IsNullOrEmpty(request.TextFilter))
            {
                switch (request.NumFilter)
                {
                    case 1:
                        categories = categories.Where(x => x.NombreCategoria!.Contains(request.TextFilter));
                        break;
                }
            }

            if (request.StateFilter is not null)
            {
                categories = categories.Where(x => x.Estado.Equals(request.StateFilter));
            }

            if (request.Sort is null) request.Sort = "Id";

            response.TotalRecords = await categories.CountAsync();
            response.Items = await Ordering(request, categories, !(bool)request.Download!).ToListAsync();

            return response;
        }
    }
}

