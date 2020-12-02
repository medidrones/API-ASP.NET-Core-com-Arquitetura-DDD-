using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Repository;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            {
                serviceCollection.AddDbContext<MyContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION")));
            }
            else
            {
                serviceCollection.AddDbContext<MyContext>(options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION")));
            }
        }
    }
}
