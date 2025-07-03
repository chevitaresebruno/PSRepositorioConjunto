
namespace ToDoList.Domain.Validation
{
    public class DomainValidationException : Exception
    {
        public List<string> Errors { get; }
        public DomainValidationException(List<string> validationsErrors)
        {
            Errors = validationsErrors;
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, Errors);
        }
    }
}