using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Utilities.Static;

namespace Infrastructure.Persistence.Repository
{
    public class UserRepository : GenericRepository<Usuario>, IUserRepository
    {
        public UserRepository(EDucaTdaContext context) : base(context) { }

        public async Task<BaseEntityResponse<Usuario>> ListUsers(BaseFiltersRequest filtersRequest)
        {
            var response = new BaseEntityResponse<Usuario>();
            var users = GetEntityQuery().Where(x => x.Estado.Equals(Convert.ToBoolean(Convert.ToInt32(StateTypes.Active))));

            if (filtersRequest.NumFilter is not null && !string.IsNullOrEmpty(filtersRequest.TextFilter))
            {
                switch (filtersRequest.NumFilter)
                {
                    case 1:
                        users = users.Where(x => x.Nombres!.Contains(filtersRequest.TextFilter));
                        break;
                    case 2:
                        users = users.Where(x => x.Apellidos!.Contains(filtersRequest.TextFilter));
                        break;
                }
            }

            if (filtersRequest.StateFilter is not null)
            {
                users = users.Where(x => x.Estado.Equals(filtersRequest.StateFilter));
            }

            if (filtersRequest.Sort is null) filtersRequest.Sort = "Id";

            response.TotalRecords = await users.CountAsync();
            response.Items = await Ordering(filtersRequest, users, !(bool)filtersRequest.Download!).ToListAsync();

            return response;
        }
    }
}
