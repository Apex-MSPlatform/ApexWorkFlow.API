using Domain.primitives;

namespace Domain.Exceptions
{
    public class DataValidationException(List<string> errors) : ApexException("ValidationException", 400, errors)
    {

    }
}