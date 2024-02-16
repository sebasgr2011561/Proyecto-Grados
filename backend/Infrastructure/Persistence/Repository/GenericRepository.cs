using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;

namespace Infrastructure.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EDucaTdaContext _context;

        public GenericRepository(EDucaTdaContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterAsync(T entity)
        {
            await _context.AddAsync(entity);
            int recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }
    }
}
