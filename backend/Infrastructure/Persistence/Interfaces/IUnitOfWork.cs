namespace Infrastructure.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        ILoginRepository Login { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
