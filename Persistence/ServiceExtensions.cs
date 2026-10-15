using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceServices(this IServiceCollection services,
                                                        IConfiguration configuration)
        {
            var connctionString = configuration.GetConnectionString("Sqlite");
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(connctionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBaseRepository<User>, UserRepository>();
        }
    }
}