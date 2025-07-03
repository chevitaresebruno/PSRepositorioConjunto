
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;
namespace ToDoList.Infrastructure.EntitiesConfiguration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder
                .HasMany<Usuario>(categoria => categoria.Usuarios) 
                .WithOne(usuario => usuario.Categoria) 
                .HasForeignKey(categoria => categoria.UsuarioCategoriaId);
            builder
                .HasMany<Tarefa>(categoria => categoria.Tarefas) 
                .WithOne(tarefa => tarefa.Categoria) 
                .HasForeignKey(categoria => categoria.TarefaCategoriaId);
        }
    }
}
