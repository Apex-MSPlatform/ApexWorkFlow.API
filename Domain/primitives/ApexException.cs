namespace Domain.primitives
{
    public abstract class ApexException(string message, int statusCode, IEnumerable<string>? errors = null) : Exception(message)
    {
        public int StatusCode { get; } = statusCode;

        public IEnumerable<string>? Errors { get; set; } = errors ?? new List<string>();
    }
}
