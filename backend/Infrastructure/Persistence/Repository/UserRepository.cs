using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class UserRepository : GenericRepository<Usuario>, IUserRepository
    {
        private readonly EDucaTdaContext _context;

        public UserRepository(EDucaTdaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> AccountByUserName(string userName)
        {
            var account = await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email!.Equals(userName));

            return account!;
        }
    }
}
