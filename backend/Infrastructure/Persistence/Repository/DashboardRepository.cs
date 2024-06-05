using System;
using Azure.Core;
using Domain.Entities;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Utilities.Static;

namespace Infrastructure.Persistence.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly EDucaTdaContext _context;

        public DashboardRepository(EDucaTdaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dashboard>> InfoDashboardActive(int idProfesor)
        {
            IEnumerable<Dashboard> dataDashboard = (from a in _context.Asignacions
                                                    join r in _context.Recursos on a.IdRecurso equals r.Id 
                                                    where r.IdProfesor == idProfesor && a.Estado == Convert.ToBoolean(StateTypes.Active)
                                                    group r by new { r.NombreRecurso } into estudiantes
                                                    select new Dashboard
                                                    {
                                                        EstudiantesRegistrados = estudiantes.Count(),
                                                        NombreRecurso = estudiantes.Key.NombreRecurso
                                                    }).ToList();

            return dataDashboard;
        }

        public async Task<IEnumerable<Dashboard>> InfoDashboardInactive(int idProfesor)
        {
            IEnumerable<Dashboard> dataDashboard = (from a in _context.Asignacions
                                                    join r in _context.Recursos on a.IdRecurso equals r.Id
                                                    where r.IdProfesor == idProfesor && a.Estado == Convert.ToBoolean(StateTypes.Inactive)
                                                    group r by new { r.NombreRecurso } into estudiantes
                                                    select new Dashboard
                                                    {
                                                        EstudiantesRegistrados = estudiantes.Count(),
                                                        NombreRecurso = estudiantes.Key.NombreRecurso
                                                    }).ToList();

            return dataDashboard;
        }
    }
}

