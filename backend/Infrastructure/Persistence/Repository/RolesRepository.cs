using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class RolesRepository : GenericRepository<Role>, IRolesRepository
    {
        public RolesRepository(EDucaTdaContext context) : base(context) { }

        public async Task<BaseEntityResponse<Role>> ListRoles(BaseFiltersRequest filtersRequest)
        {
            var response = new BaseEntityResponse<Role>();
            var roles = GetEntityQuery();

            if (filtersRequest.NumFilter is not null && !string.IsNullOrEmpty(filtersRequest.TextFilter))
            {
                switch (filtersRequest.NumFilter)
                {
                    case 1:
                        roles = roles.Where(x => x.Descripcion!.Contains(filtersRequest.TextFilter));
                        break;
                }
            }

            if (filtersRequest.StateFilter is not null)
            {
                roles = roles.Where(x => x.Estado.Equals(filtersRequest.StateFilter));
            }

            if (filtersRequest.Sort is null) filtersRequest.Sort = "Id";

            response.TotalRecords = await roles.CountAsync();
            response.Items = await Ordering(filtersRequest, roles, !(bool)filtersRequest.Download!).ToListAsync();

            return response;
        }
    }
}
