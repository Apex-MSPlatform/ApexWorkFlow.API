using Domain.primitives;

namespace Domain.Exceptions
{
    public class NoRecordsFoundException : ApexException
    {
        public NoRecordsFoundException(string entityName) : base($"No {entityName} records found.", 404)
        {

        }
    }
}