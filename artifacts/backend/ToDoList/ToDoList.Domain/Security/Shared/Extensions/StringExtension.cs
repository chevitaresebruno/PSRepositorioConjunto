
using System.Text;
namespace ToDoList.Domain.Security.Shared.Extensions
{
    public static class StringExtension
    {
        public static string ToBase64(this string text) => Convert.ToBase64String(Encoding.ASCII.GetBytes(text));
    }
}