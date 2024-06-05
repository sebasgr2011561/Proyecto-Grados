using System;
using Domain.Entities;
using Infrastructure.Commons.Bases.Response;

namespace Infrastructure.Persistence.Interfaces
{
	public interface IDashboardRepository
    {
        Task<IEnumerable<Dashboard>> InfoDashboardActive(int idProfesor);
        Task<IEnumerable<Dashboard>> InfoDashboardInactive(int idProfesor);
    }
}

