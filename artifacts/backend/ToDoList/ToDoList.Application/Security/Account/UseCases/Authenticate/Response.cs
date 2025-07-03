
using Flunt.Notifications;

namespace ToDoList.Application.Security.Account.UseCases.Authenticate
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

        public Response(string message)
        {
            Message = message;
            Status = 200;
        }

        public ResponseData? Data { get; set; }
    }

    public class ResponseData
    {
        public string Token { get; set; } = string.Empty;
        public DateTime? TokenExpires { get; set; }
        public Guid? RefreshToken { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string[] Roles { get; set; } = Array.Empty<string>();
    }
}