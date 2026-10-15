using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IBaseRepository<User>
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> GetByEmail(string email, CancellationToken cancellation)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellation);
        }
    }
}