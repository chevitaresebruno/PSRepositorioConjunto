
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Interfaces.Security;
using ToDoList.Domain.Security.Account.Entities;
using ToDoList.Infrastructure.Context;
namespace ToDoList.Infrastructure.Security.Repositories
{
    public class UserRepository : BaseSecurityRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public Task<bool> AnyAsync(string email, CancellationToken cancelationToken)
        {
            return
                _context.Users
                        .AsNoTracking()
                        .AnyAsync(x => x.Email.Address == email);
        }
        public Task<User?> GetUserByCode(string code, CancellationToken cancellationToken)
        {
            return _context.Users
                        .Include(x => x.Roles)
                        .FirstOrDefaultAsync(x => x.Email.Verification.Code == code, cancellationToken: cancellationToken);
        }
        public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return _context.Users
                        .Include(x => x.Roles)
                        .FirstOrDefaultAsync(x => x.Email.Address == email);
        }
        public Task<User?> GetUserByPasswordCode(string code, CancellationToken cancellationToken)
        {
            return _context.Users
                        .Include(x => x.Roles)
                        .FirstOrDefaultAsync(x => x.Password.ResetCode == code, cancellationToken: cancellationToken);
        }
        public Task<User?> GetUserByRefreshCode(Guid refreshToken, CancellationToken cancellationToken)
        {
            return _context.Users
                        .Include(x => x.Roles)
                        .FirstOrDefaultAsync(x => x.RefreshToken == refreshToken, cancellationToken: cancellationToken);
        }
    }
}