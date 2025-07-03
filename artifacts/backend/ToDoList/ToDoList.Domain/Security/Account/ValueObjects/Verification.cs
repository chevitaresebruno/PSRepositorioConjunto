
using ToDoList.Domain.Security.Shared.ValueObjects;
namespace ToDoList.Domain.Security.Account.ValueObjects
{
    public class Verification : ValueObject
    {
        // Gera um Guid sem o simbolo (-) e e retorna apenas os 6 primeiros dígitos
        public string Code { get; } = Guid.NewGuid().ToString("N")[0..6].ToUpper();
        public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddMinutes(10);
        public DateTime? VerifiedAt { get; private set; } = null;
        public bool IsActive => VerifiedAt != null && ExpiresAt == null;
        public Verification() { }
        public void Verify(string code)
        {
            if (IsActive)
            {
                throw new Exception("Esse código já foi ativado");
            }
            if (ExpiresAt < DateTime.UtcNow)
            {
                throw new Exception("Esse código está expirado");
            }
            if (!string.Equals(code.Trim(), Code.Trim(), StringComparison.CurrentCultureIgnoreCase))
            {
                throw new Exception("Código de verificação inválido");
            }
            ExpiresAt = null;
            VerifiedAt = DateTime.UtcNow;
        }
    }
}