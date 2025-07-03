
using Flunt.Notifications;
using Flunt.Validations;

namespace ToDoList.Application.Security.Account.UseCases.RefreshToken
{
    public static class Specification
    {
        public static Contract<Notification> Ensure(Request request)
              => new Contract<Notification>()
                    .Requires()
                    .IsNotNull(request.RefreshToken, "O Refresh Token não pode ser nulo");
    }
}