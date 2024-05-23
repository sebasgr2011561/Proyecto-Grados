using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class RoutesRepository : GenericRepository<Ruta>, IRoutesRepository
    {
        public RoutesRepository(EDucaTdaContext context) : base(context)
        {
        }

        public async Task<BaseEntityResponse<Ruta>> ListRoutes(BaseFiltersRequest filtersRequest)
        {
            var response = new BaseEntityResponse<Ruta>();
            var routes = GetEntityQuery();

            if (filtersRequest.NumFilter is not null && !string.IsNullOrEmpty(filtersRequest.TextFilter))
            {
                switch (filtersRequest.NumFilter)
                {
                    case 1:
                        routes = routes.Where(x => x.IdEstudiante.Equals(filtersRequest.TextFilter));
                        break;
                }
            }

            if (filtersRequest.StateFilter is not null)
            {
                routes = routes.Where(x => x.Estado.Equals(filtersRequest.StateFilter));
            }

            if (filtersRequest.Sort is null) filtersRequest.Sort = "Id";

            response.TotalRecords = await routes.CountAsync();
            response.Items = await Ordering(filtersRequest, routes, !(bool)filtersRequest.Download!).ToListAsync();

            return response;
        }
    }
}
