﻿using Infrastructure.FileStorage;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILoginRepository Login { get; }
        IUserRepository User { get; }
        ICoursesRepository Courses { get; }
        IAssignmentsRepository Assignments { get; }
        IAsociacionRutaRepository AsociacionRuta { get; }
        IRolesRepository Roles { get; }
        IRoutesRepository Routes { get; }
        IPermitsRepository Permits { get; }
        IQualificationsRepository Qualifications { get; }
        ICategoryRepository Categories { get; }
        IModuloRepository Modulos { get; }
        IDashboardRepository Dashboard { get; }
        IAzureStorage AzureStorage { get; }


        void SaveChanges();
        Task SaveChangesAsync();
    }
}
