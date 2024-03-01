using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;

namespace Infrastructure.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EDucaTdaContext _context;
        public ILoginRepository Login { get; private set; }
        public IUserRepository User { get; private set; }
        public ICoursesRepository Courses { get; private set; }
        public IAssignmentsRepository Assignments { get; private set; }
        public IRolesRepository Roles { get; private set; }

        public UnitOfWork(EDucaTdaContext context)
        {
            _context = context;
            Login = new LoginRepository(_context);
            User = new UserRepository(_context);
            Courses = new CoursesRepository(_context);
            Assignments = new AssignmentsRepository(_context);
            Roles = new RolesRepository(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
