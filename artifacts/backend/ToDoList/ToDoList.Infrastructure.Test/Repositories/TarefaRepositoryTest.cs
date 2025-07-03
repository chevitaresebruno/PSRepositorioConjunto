
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
    public class TarefaRepositoryTest
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly AppDbContext _context;
        private readonly Fixture _entityfixture;
        public TarefaRepositoryTest(SharedTestConfiguration sharedTestConfiguration)
        {
            var _configuration = sharedTestConfiguration.GetConfiguration();
            var _scope = sharedTestConfiguration.GetServices().CreateScope();
            _context = _scope.ServiceProvider.GetRequiredService<AppDbContext>();
            _tarefaRepository = _scope.ServiceProvider.GetRequiredService<ITarefaRepository>();
            this._entityfixture = TestHelper.GetFixture();
        }
        [Fact]
        public void GetAllTarefas()
        {
            var result = _tarefaRepository.GetAll();
            var connection = _context.Database.GetDbConnection();
            Assert.NotNull(result);
        }
        [Fact]
        public async Task InsertTarefa()
        {
            var tarefa = this._entityfixture.Build<Tarefa>()
                .Create(); 
            await _tarefaRepository.Create(tarefa);
            var resultInsert = await _context.SaveChangesAsync();
            var result =  _tarefaRepository.GetById(tarefa.Id).FirstOrDefault();
            Assert.NotNull(result);
        }
        [Fact]
        public async Task UpdateTarefa()
        {
            #region Create Tarefa
            var tarefa = this._entityfixture.Build<Tarefa>()
                .Create(); 
            await _tarefaRepository.Create(tarefa);
            await _context.SaveChangesAsync();
            #endregion
            #region Update Tarefa
            tarefa.Nome = "Updated Name";
            await _tarefaRepository.Update(tarefa);
            await _context.SaveChangesAsync();
            #endregion
            #region Check Results
            var result = _tarefaRepository.GetById(tarefa.Id).FirstOrDefault();
            Assert.NotNull(result);
            Assert.Equal("Updated Name", result.Nome);
            #endregion
        }
        [Fact]
        public async Task DeleteTarefa()
        {
            #region Create Tarefa
            var tarefa = this._entityfixture.Build<Tarefa>()
                .Create(); 
            await _tarefaRepository.Create(tarefa);
            await _context.SaveChangesAsync();
            #endregion
            #region Delete Tarefa
            await _tarefaRepository.Delete(tarefa);
            await _context.SaveChangesAsync();
            #endregion
            #region Check Results
            var result = _tarefaRepository.GetById(tarefa.Id).FirstOrDefault();
            Assert.Null(result);
            #endregion
        }
        [Fact]
        public async Task GetTarefa()
        {
            #region Create Tarefa
            var tarefa = this._entityfixture.Build<Tarefa>()
                .Create(); 
            await _tarefaRepository.Create(tarefa);
            await _context.SaveChangesAsync();
            #endregion
            #region Get Tarefa
            var result = _tarefaRepository.GetById(tarefa.Id).FirstOrDefault();
            #endregion
            #region Check Results
            Assert.NotNull(result);
            Assert.Equal(tarefa.Id, result.Id);
            #endregion
        }
    }
}