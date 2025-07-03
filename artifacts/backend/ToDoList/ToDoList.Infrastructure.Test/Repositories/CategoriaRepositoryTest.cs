
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
    public class CategoriaRepositoryTest
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly AppDbContext _context;
        private readonly Fixture _entityfixture;
        public CategoriaRepositoryTest(SharedTestConfiguration sharedTestConfiguration)
        {
            var _configuration = sharedTestConfiguration.GetConfiguration();
            var _scope = sharedTestConfiguration.GetServices().CreateScope();
            _context = _scope.ServiceProvider.GetRequiredService<AppDbContext>();
            _categoriaRepository = _scope.ServiceProvider.GetRequiredService<ICategoriaRepository>();
            this._entityfixture = TestHelper.GetFixture();
        }
        [Fact]
        public void GetAllCategorias()
        {
            var result = _categoriaRepository.GetAll();
            var connection = _context.Database.GetDbConnection();
            Assert.NotNull(result);
        }
        [Fact]
        public async Task InsertCategoria()
        {
            var categoria = this._entityfixture.Build<Categoria>()
                
.With(Categoria => Categoria.Usuario, [])
.With(Categoria => Categoria.Tarefa, []).Create(); 
            await _categoriaRepository.Create(categoria);
            var resultInsert = await _context.SaveChangesAsync();
            var result =  _categoriaRepository.GetById(categoria.Id).FirstOrDefault();
            Assert.NotNull(result);
        }
        [Fact]
        public async Task UpdateCategoria()
        {
            #region Create Categoria
            var categoria = this._entityfixture.Build<Categoria>()
                
.With(Categoria => Categoria.Usuario, [])
.With(Categoria => Categoria.Tarefa, []).Create(); 
            await _categoriaRepository.Create(categoria);
            await _context.SaveChangesAsync();
            #endregion
            #region Update Categoria
            categoria.Nome = "Updated Name";
            await _categoriaRepository.Update(categoria);
            await _context.SaveChangesAsync();
            #endregion
            #region Check Results
            var result = _categoriaRepository.GetById(categoria.Id).FirstOrDefault();
            Assert.NotNull(result);
            Assert.Equal("Updated Name", result.Nome);
            #endregion
        }
        [Fact]
        public async Task DeleteCategoria()
        {
            #region Create Categoria
            var categoria = this._entityfixture.Build<Categoria>()
                
.With(Categoria => Categoria.Usuario, [])
.With(Categoria => Categoria.Tarefa, []).Create(); 
            await _categoriaRepository.Create(categoria);
            await _context.SaveChangesAsync();
            #endregion
            #region Delete Categoria
            await _categoriaRepository.Delete(categoria);
            await _context.SaveChangesAsync();
            #endregion
            #region Check Results
            var result = _categoriaRepository.GetById(categoria.Id).FirstOrDefault();
            Assert.Null(result);
            #endregion
        }
        [Fact]
        public async Task GetCategoria()
        {
            #region Create Categoria
            var categoria = this._entityfixture.Build<Categoria>()
                
.With(Categoria => Categoria.Usuario, [])
.With(Categoria => Categoria.Tarefa, []).Create(); 
            await _categoriaRepository.Create(categoria);
            await _context.SaveChangesAsync();
            #endregion
            #region Get Categoria
            var result = _categoriaRepository.GetById(categoria.Id).FirstOrDefault();
            #endregion
            #region Check Results
            Assert.NotNull(result);
            Assert.Equal(categoria.Id, result.Id);
            #endregion
        }
    }
}