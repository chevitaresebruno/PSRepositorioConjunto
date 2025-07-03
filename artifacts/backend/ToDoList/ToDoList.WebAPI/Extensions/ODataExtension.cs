
using ToDoList.Application.DTOs.Entities.Response;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace ToDoList.WebApi.Extensions
{
    public static class ODataExtension
    {
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new();
            builder.EntitySet<UsuarioResponseDTO>("usuario"); 
builder.EntitySet<CategoriaResponseDTO>("categoria"); 
builder.EntitySet<TarefaResponseDTO>("tarefa"); 

            return builder.GetEdmModel();
        }

        public static void ODataConfiguration(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                // Add filter exceptions here
            })
            .AddOData(options => options
                .SkipToken()
                .AddRouteComponents("api", GetEdmModel())
                .Select()
                .Filter()
                .OrderBy()
                .SetMaxTop(4)
                .Count()
                .Expand());
        }
    }
}