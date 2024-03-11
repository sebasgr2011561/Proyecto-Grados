using System;
using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class QualificationsRepository : GenericRepository<Calificacione>, IQualificationsRepository
    {
        public QualificationsRepository(EDucaTdaContext context) : base(context) { }

        public async Task<BaseEntityResponse<Calificacione>> ListQualifications(BaseFiltersRequest request)
        {
            var response = new BaseEntityResponse<Calificacione>();
            var qualifications = GetEntityQuery();

            if (request.NumFilter is not null && !string.IsNullOrEmpty(request.TextFilter))
            {
                switch (request.NumFilter)
                {
                    case 1:
                        qualifications = qualifications.Where(x => x.Calificacion.Equals(request.TextFilter));
                        break;
                }
            }

            if (request.StateFilter is not null)
            {
                qualifications = qualifications.Where(x => x.Estado.Equals(request.StateFilter));
            }

            if (request.Sort is null) request.Sort = "Id";

            response.TotalRecords = await qualifications.CountAsync();
            response.Items = await Ordering(request, qualifications, !(bool)request.Download!).ToListAsync();

            return response;
        }
    }
}

