using Domain.Entities;
using Domain.EntitiesDto;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IAssignmentsRepository : IGenericRepository<Asignacion>
    {
        Task<BaseEntityResponse<Asignacion>> ListAssignments(BaseFiltersRequest request);
        Task<BaseEntityResponse<AssignmentDto>> AssignmentsByStudent(int studentId);
    }
}
