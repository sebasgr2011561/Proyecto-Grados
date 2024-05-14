using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IModuloRepository : IGenericRepository<Modulo>
    {
        Task<BaseEntityResponse<Modulo>> ListModules(BaseFiltersRequest request);
    }
}
