using Domain.Entities;
using Domain.EntitiesDto;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Infrastructure.Persistence.Repository
{
    public class AssignmentsRepository : GenericRepository<Asignacion>, IAssignmentsRepository
    {
        private readonly EDucaTdaContext _context;
        public AssignmentsRepository(EDucaTdaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BaseEntityResponse<AssignmentDto>> AssignmentsByStudent(int studentId)
        {
            var response = new BaseEntityResponse<AssignmentDto>();

            var assignmentsByStudent = (from a in _context.Asignacions.ToList()
                                        join r in _context.Recursos.ToList() on a.IdRecurso equals r.Id
                                        where a.Id == studentId
                                        select new AssignmentDto
                                        {
                                            NombreRecurso = r.NombreRecurso,
                                            Descripcion = r.Descripcion,
                                            ImagenPortada = r.ImagenPortada,
                                            Duracion = r.Duracion,
                                            Precio = r.Precio,
                                            FechaAsignacion = a.FechaAsignacion
                                        }).ToList();

            response.Items = assignmentsByStudent;

            return response!;
        }

        public async Task<BaseEntityResponse<Asignacion>> ListAssignments(BaseFiltersRequest request)
        {
            var response = new BaseEntityResponse<Asignacion>();
            var assignments = GetEntityQuery();


            if (request.StateFilter is not null)
            {
                assignments = assignments.Where(x => x.Estado.Equals(request.StateFilter));
            }

            if (request.Sort is null) request.Sort = "Id";

            response.TotalRecords = await assignments.CountAsync();
            response.Items = await Ordering(request, assignments, !(bool)request.Download!).ToListAsync();

            return response;
        }
    }
}
