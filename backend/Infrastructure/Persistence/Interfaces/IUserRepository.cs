using Domain.Entities;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IUserRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> AccountByUserName(string userName);
    }
}
