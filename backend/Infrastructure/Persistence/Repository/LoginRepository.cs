﻿using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class LoginRepository : GenericRepository<Usuario>, ILoginRepository
    {
        private readonly EDucaTdaContext _context;

        public LoginRepository(EDucaTdaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> AccountByUserName(string userName)
        {
            var userAccount = await _context.Usuarios!
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email.Equals(userName));

            return userAccount!;
        }
    }
}
