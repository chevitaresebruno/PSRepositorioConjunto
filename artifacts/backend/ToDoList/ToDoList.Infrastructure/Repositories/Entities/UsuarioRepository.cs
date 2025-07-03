
﻿using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Interfaces.Entities;
using ToDoList.Infrastructure.Context;
using ToDoList.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;
namespace ToDoList.Infrastructure.Repositories.Entities
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context) { }
    }
}