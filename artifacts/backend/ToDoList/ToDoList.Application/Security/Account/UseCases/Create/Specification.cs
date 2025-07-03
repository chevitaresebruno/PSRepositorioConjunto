
using Flunt.Notifications;
using Flunt.Validations;


namespace ToDoList.Application.Security.Account.UseCases.Create
{
    public static class Specification
    {
        public static Contract<Notification> Ensure(Request request)
              => new Contract<Notification>()
                    .Requires()
                    .IsLowerThan(request.Name.Length, 100, "Name", "O nome deve conter menos que 100 caracteres")
                    .IsGreaterThan(request.Name.Length, 3, "Name", "O nome deve conter mais que 3 caracteres")
                    .IsLowerThan(request.Password.Length, 40, "Password", "A senha deve conter menos que 40 caracteres")
                    .IsGreaterThan(request.Password.Length, 5, "Password", "A senha deve conter mais que 5 caracteres")
                    .IsEmail(request.Email, "Email", "E-mail inválido");
    }
}