using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IRolesRepository : IGenericRepository<Role>
    {
        Task<BaseEntityResponse<Role>> ListRoles(BaseFiltersRequest filtersRequest);
    }
}
