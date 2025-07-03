
using Flunt.Notifications;
using Flunt.Validations;

namespace ToDoList.Application.Security.Account.UseCases.Verify
{
    public static class Specification
    {
        public static Contract<Notification> Ensure(Request request)
              => new Contract<Notification>()
                    .Requires()
                    .IsGreaterThan(request.Code.Length, 5, "Código de verificação", "O código de verificação deve conter mais que 3 caracteres");
    }
}