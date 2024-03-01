namespace Infrastructure.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILoginRepository Login { get; }
        IUserRepository User { get; }
        ICoursesRepository Courses { get; }
        IAssignmentsRepository Assignments { get; }
        IRolesRepository Roles { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
