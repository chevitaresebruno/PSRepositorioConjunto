
using Flunt.Notifications;

namespace ToDoList.Application.Security.Account.UseCases.Create
{
    public class Response : Shared.UseCases.Response
    {
        protected Response() { }

        public Response(
            string message,
            int status,
            IEnumerable<Notification>? notifications = null)
        {
            Message = message;
            Status = status;
            Notifications = notifications;
        }

        public Response(string message, ResponseData data)
        {
            Message = message;
            Status = 201;
            Notifications = null;
            Data = data;
        }

        public ResponseData? Data { get; set; }
    }

    public record ResponseData(Guid id, string name, string email);
}