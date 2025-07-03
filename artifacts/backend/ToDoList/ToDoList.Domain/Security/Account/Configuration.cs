
namespace ToDoList.Domain.Security.Account
{
    public static class Configuration
    {
        public static SecretsConfiguration Secrets { get; set; } = new();
        public static EmailConfiguration Email { get; set; } = new();
        public class EmailConfiguration
        {
            public string DefaultFromEmail { get; set; } = string.Empty;
            public string ApiKey { get; set; } = string.Empty;
        }
        public class SecretsConfiguration
        {
            public string ApiKey { get; set; } = string.Empty;
            public string JwtPrivateKey { get; set; } = string.Empty;
            public string PasswordSaltKey { get; set; } = string.Empty;
        }
    }
}