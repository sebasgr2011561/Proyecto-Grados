using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class CoursesRepository : GenericRepository<Recurso>, ICoursesRepository
    {
        public CoursesRepository(EDucaTdaContext context) : base(context) { }

        public async Task<BaseEntityResponse<Recurso>> ListCoursers(BaseFiltersRequest request)
        {
            var response = new BaseEntityResponse<Recurso>();
            var courses = GetEntityQuery();

            if (request.NumFilter is not null && !string.IsNullOrEmpty(request.TextFilter))
            {
                switch (request.NumFilter)
                {
                    case 1:
                        courses = courses.Where(x => x.NombreRecurso!.Contains(request.TextFilter));
                        break;
                }
            }

            if (request.StateFilter is not null)
            {
                courses = courses.Where(x => x.Estado.Equals(request.StateFilter));
            }

            if (request.Sort is null) request.Sort = "Id";

            response.TotalRecords = await courses.CountAsync();
            response.Items = await Ordering(request, courses, !(bool)request.Download!).ToListAsync();

            return response;
        }
    }
}
