
using System.Text.Json.Serialization;

namespace ToDoList.Application.DTOs.Common
{
    public class ApiResponse : ResponseBase
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Uri { get; set; }
        public string Message { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Body { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Errors { get; set; }


        public ApiResponse(int Estado, string message) : base(Estado)
        {
            Message = message;
        }

        public ApiResponse(int Estado, string? uri, string message) : base(Estado)
        {
            Uri = uri;
            Message = message;
        }

        public ApiResponse(int Estado, string? uri, string message, object body) : base(Estado)
        {
            Uri = uri;
            Message = message;
            Body = body;
        }

        public ApiResponse(int Estado, string? uri, string message, List<string>? errors) : base(Estado)
        {
            Uri = uri;
            Message = message;
            Errors = errors;
        }
    }
}