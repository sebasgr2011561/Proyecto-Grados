using Domain.Entities;

namespace Infrastructure.Persistence.Interfaces
{
    public interface ILoginRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> AccountByUserName(string userName);
    }
}
