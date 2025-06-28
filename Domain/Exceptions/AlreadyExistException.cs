using Domain.primitives;

namespace Domain.Exceptions
{
    public class AlreadyExistException(ICollection<string> errors) 
        : ApexException("Already Exist Exception", 409, errors)
    {

    }
}
