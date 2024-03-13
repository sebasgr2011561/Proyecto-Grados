using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IQualificationsRepository : IGenericRepository<Calificacione>
    {
        Task<BaseEntityResponse<Calificacione>> ListQualifications(BaseFiltersRequest request);
    }
}

