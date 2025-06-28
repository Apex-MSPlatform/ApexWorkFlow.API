using Domain.primitives;

namespace Domain.Exceptions
{
    public class InvalidInputException : ApexException
    {
        public InvalidInputException(string id, string message = "is invalid")
            : base($"{id} {message}", 400)
        {
        }
    }
}