
using ToDoList.Domain.Security.Shared.Extensions;
using ToDoList.Domain.Security.Shared.ValueObjects;
using System.Text.RegularExpressions;
namespace ToDoList.Domain.Security.Account.ValueObjects
{
    public partial class Email : ValueObject
    {
        private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public string Address { get; }
        public string Hash => Address.ToBase64();
        public Verification Verification { get; private set; } = new();
        public void ResendVerification() => Verification = new Verification();
        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();
        protected Email() { }
        public Email(string address)
        {
            // Validações
            if (string.IsNullOrEmpty(address))
                throw new Exception("E-mail inválido");
            Address = address.Trim().ToLower();
            if (Address.Length < 5)
                throw new Exception("E-mail inválido");
            if (!EmailRegex().IsMatch(Address))
                throw new Exception("E-mail inválido");
        }
        // Conversão implicita de email para string
        public static implicit operator string(Email email) => email.ToString();
        // Conversão implicita de string para email
        public static implicit operator Email(string address) => new(address);
    }
}