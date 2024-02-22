using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IUserRepository : IGenericRepository<Usuario>
    {
        Task<BaseEntityResponse<Usuario>> ListUsers(BaseFiltersRequest filtersRequest);
    }
}