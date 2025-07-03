
using ToDoList.Domain.Interfaces;
using ToDoList.Infrastructure.Context;
using ToDoList.Infrastructure.Repositories;
using ToDoList.Domain.Interfaces.Security;
using ToDoList.Domain.Interfaces.Common;
using ToDoList.Domain.Interfaces.Entities;
using ToDoList.Infrastructure.Repositories.Entities;
using ToDoList.Infrastructure.Security.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace ToDoList.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("SqlServer");
            IServiceCollection serviceCollection = services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString, x => x.MigrationsAssembly("ToDoList.Infrastructure")), ServiceLifetime.Scoped);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>(); 
services.AddScoped<ICategoriaRepository, CategoriaRepository>(); 
services.AddScoped<ITarefaRepository, TarefaRepository>(); 
        }
    }
}