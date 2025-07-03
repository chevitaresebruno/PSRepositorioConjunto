
using AutoFixture;
using ToDoList.Domain.Entities.CadastroModalidadesBolsas;
using ToDoList.Domain.Interfaces.CadastroModalidadesBolsas;
using ToDoList.Infrastructure.Context;
using ToDoList.Infrastructure.Test.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace ToDoList.Infrastructure.Test.Repositories
{
    [Collection(SharedTestConfigurationParameters.CollectionName)]
    public class UsuarioRepositoryTest
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly AppDbContext _context;
        private readonly Fixture _entityfixture;
        public UsuarioRepositoryTest(SharedTestConfiguration sharedTestConfiguration)
        {
            var _configuration = sharedTestConfiguration.GetConfiguration();
            var _scope = sharedTestConfiguration.GetServices().CreateScope();
            _context = _scope.ServiceProvider.GetRequiredService<AppDbContext>();
            _usuarioRepository = _scope.ServiceProvider.GetRequiredService<IUsuarioRepository>();
            this._entityfixture = TestHelper.GetFixture();
        }
        [Fact]
        public void GetAllUsuarios()
        {
            var result = _usuarioRepository.GetAll();
            var connection = _context.Database.GetDbConnection();
            Assert.NotNull(result);
        }
        [Fact]
        public async Task InsertUsuario()
        {
            var usuario = this._entityfixture.Build<Usuario>()
                
.With(Usuario => Usuario.Tarefa, []).Create(); 
            await _usuarioRepository.Create(usuario);
            var resultInsert = await _context.SaveChangesAsync();
            var result =  _usuarioRepository.GetById(usuario.Id).FirstOrDefault();
            Assert.NotNull(result);
        }
        [Fact]
        public async Task UpdateUsuario()
        {
            #region Create Usuario
            var usuario = this._entityfixture.Build<Usuario>()
                
.With(Usuario => Usuario.Tarefa, []).Create(); 
            await _usuarioRepository.Create(usuario);
            await _context.SaveChangesAsync();
            #endregion
            #region Update Usuario
            usuario.Nome = "Updated Name";
            await _usuarioRepository.Update(usuario);
            await _context.SaveChangesAsync();
            #endregion
            #region Check Results
            var result = _usuarioRepository.GetById(usuario.Id).FirstOrDefault();
            Assert.NotNull(result);
            Assert.Equal("Updated Name", result.Nome);
            #endregion
        }
        [Fact]
        public async Task DeleteUsuario()
        {
            #region Create Usuario
            var usuario = this._entityfixture.Build<Usuario>()
                
.With(Usuario => Usuario.Tarefa, []).Create(); 
            await _usuarioRepository.Create(usuario);
            await _context.SaveChangesAsync();
            #endregion
            #region Delete Usuario
            await _usuarioRepository.Delete(usuario);
            await _context.SaveChangesAsync();
            #endregion
            #region Check Results
            var result = _usuarioRepository.GetById(usuario.Id).FirstOrDefault();
            Assert.Null(result);
            #endregion
        }
        [Fact]
        public async Task GetUsuario()
        {
            #region Create Usuario
            var usuario = this._entityfixture.Build<Usuario>()
                
.With(Usuario => Usuario.Tarefa, []).Create(); 
            await _usuarioRepository.Create(usuario);
            await _context.SaveChangesAsync();
            #endregion
            #region Get Usuario
            var result = _usuarioRepository.GetById(usuario.Id).FirstOrDefault();
            #endregion
            #region Check Results
            Assert.NotNull(result);
            Assert.Equal(usuario.Id, result.Id);
            #endregion
        }
    }
}