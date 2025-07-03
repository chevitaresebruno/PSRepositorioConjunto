
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;
namespace ToDoList.Infrastructure.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder
                .HasMany<Tarefa>(usuario => usuario.Tarefas) 
                .WithOne(tarefa => tarefa.Usuario) 
                .HasForeignKey(usuario => usuario.TarefaUsuarioId);
        }
    }
}
