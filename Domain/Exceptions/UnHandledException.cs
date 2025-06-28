using Domain.primitives;

namespace Domain.Exceptions
{
    public class UnHandledException : ApexException
    {
        public UnHandledException(string message, IEnumerable<string>? errors, int statusCode = 400) : base(message, statusCode, errors)
        {

        }
    }
}
