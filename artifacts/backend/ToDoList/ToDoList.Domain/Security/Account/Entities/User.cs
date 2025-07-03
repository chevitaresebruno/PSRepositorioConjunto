
using ToDoList.Domain.Security.Account.ValueObjects;
using ToDoList.Domain.Security.Shared.Entities;
namespace ToDoList.Domain.Security.Account.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; } = string.Empty;
        public Email Email { get; private set; } = null!;
        public Password Password { get; private set; } = null!;
        public List<Role> Roles { get; set; } = [];
        public Guid? RefreshToken { get; set; }
        protected User() { }
        public User(string name, Email email, Password password, Guid? refreshToken)
        {
            Name = name;
            Email = email;
            Password = password;
            RefreshToken = refreshToken;
            Roles = new List<Role>();
        }
        public User(string name, Email email, Password password)
        {
            Name = name;
            Email = email;
            Password = password;
            Roles = new List<Role>();
        }
        public void UpdatePassword(string plainTextPassword, string code)
        {
            if (!string.Equals(code.Trim(), Password.ResetCode.Trim(), StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Código de restauração inválido");
            var password = new Password(plainTextPassword);
            Password = password;
        }
        public void UpdateEmail(Email email)
        {
            Email = email;
        }
        public void UpdateRefreshToken(Guid? token)
        {
            RefreshToken = token;
        }
        public void addRole(Role role)
        {
            Roles.Add(role);
        }
    }
}