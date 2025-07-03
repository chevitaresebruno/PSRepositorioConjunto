
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Interfaces.Entities;
using ToDoList.Application.Services.Entities;
using ToDoList.Application.Security.Interfaces;
using ToDoList.Application.Security.Services;
using ToDoList.Application.Shared.Behavior;
using System.Reflection;

namespace ToDoList.Application.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddTransient<IService, EmailService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
services.AddScoped<ICategoriaService, CategoriaService>();
services.AddScoped<ITarefaService, TarefaService>();

        }
    }
}