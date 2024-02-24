using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Infrastructure.Persistence.Interfaces
{
    public interface ICoursesRepository : IGenericRepository<Recurso>
    {
        Task<BaseEntityResponse<Recurso>> ListCoursers(BaseFiltersRequest request);
    }
}
