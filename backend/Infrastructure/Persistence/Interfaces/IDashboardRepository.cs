using System;
using Domain.Entities;
using Infrastructure.Commons.Bases.Response;

namespace Infrastructure.Persistence.Interfaces
{
	public interface IDashboardRepository
    {
        Task<BaseEntityResponse<Dashboard>> InfoDashboard(int idProfesor);
    }
}

