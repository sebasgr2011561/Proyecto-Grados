using Domain.Entities;
using Domain.EntitiesDto;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IAssignmentsRepository : IGenericRepository<Asignacion>
    {
        Task<BaseEntityResponse<Asignacion>> ListAssignments(BaseFiltersRequest request);
        Task<BaseEntityResponse<AssignmentDto>> AssignmentsByStudent(int studentId);
    }
}
