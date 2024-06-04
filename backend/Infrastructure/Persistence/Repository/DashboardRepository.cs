using System;
using Azure.Core;
using Domain.Entities;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;

namespace Infrastructure.Persistence.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly EDucaTdaContext _context;

        public DashboardRepository(EDucaTdaContext context)
        {
            _context = context;
        }

        public async Task<BaseEntityResponse<Dashboard>> InfoDashboard(int idProfesor)
        {
            var response = new BaseEntityResponse<Dashboard>();

            var infoDashboard = (from a in _context.Asignacions.ToList()
                                 join r in _context.Recursos.ToList() on r.IdRecurso equals a.IdRecurso)


                                 from a in _context.Asignacions.ToList()
                                join r in _context.Recursos.ToList() on 
                                where r.IdProfesor == idProfesor
                                select new Dashboard()
                                {
                                    EstudiantesRegistrados = 
                                    NombreRecurso = r.NombreRecurso
                                }






            var courses = request.Id > 0 ? GetEntityQuery().Where(x => x.IdCategoria == request.Id) : GetEntityQuery();

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

