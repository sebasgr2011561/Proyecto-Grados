using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class ModuloRepository : GenericRepository<Modulo>, IModuloRepository
    {
        public ModuloRepository(EDucaTdaContext context) : base(context) { }

        public async Task<BaseEntityResponse<Modulo>> ListModules(BaseFiltersRequest request)
        {
            var response = new BaseEntityResponse<Modulo>();
            var modules = GetEntityQuery();

            if (request.NumFilter is not null && !string.IsNullOrEmpty(request.TextFilter))
            {
                switch (request.NumFilter)
                {
                    case 1:
                        modules = modules.Where(x => x.NombreModulo!.Contains(request.TextFilter));
                        break;
                }
            }

            if (request.StateFilter is not null)
            {
                modules = modules.Where(x => x.Estado.Equals(request.StateFilter));
            }

            if (request.Sort is null) request.Sort = "Id";

            response.TotalRecords = await modules.CountAsync();
            response.Items = await Ordering(request, modules, !(bool)request.Download!).ToListAsync();

            return response;
        }
    }
}
