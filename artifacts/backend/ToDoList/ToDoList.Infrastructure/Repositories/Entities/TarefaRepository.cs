
﻿using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Interfaces.Entities;
using ToDoList.Infrastructure.Context;
using ToDoList.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;
namespace ToDoList.Infrastructure.Repositories.Entities
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(AppDbContext context) : base(context) { }
    }
}