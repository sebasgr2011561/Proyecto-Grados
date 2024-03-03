using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IRoutesRepository : IGenericRepository<Ruta>
    {
        Task<BaseEntityResponse<Ruta>> ListRoutes(BaseFiltersRequest filtersRequest);
    }
}
