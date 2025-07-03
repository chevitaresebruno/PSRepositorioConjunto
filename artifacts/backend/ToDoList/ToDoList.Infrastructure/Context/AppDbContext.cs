
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Security.Account.Entities;
namespace ToDoList.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } 
public DbSet<Categoria> Categorias { get; set; } 
public DbSet<Tarefa> Tarefas { get; set; } 
    }
}