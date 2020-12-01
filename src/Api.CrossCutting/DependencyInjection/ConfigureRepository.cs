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
            serviceCollection.AddDbContext<MyContext>(options => options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=251308"));
        }
    }
}
