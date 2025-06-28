namespace Domain.Shared
{
    public class Result
    {
        public bool IsSuccess { get; protected set; }

        public string Message { get; protected set; } = "";
        public IEnumerable<string>? Errors { get; set; }

        protected Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        protected Result(bool isSuccess, string message, IEnumerable<string>? errors)
        {
            IsSuccess = isSuccess;
            Message = message;
            Errors = errors;
        }

        public static Result Success(string message) => new(true, message);
        public static Result Failure(string message, IEnumerable<string>? errors) => new(false, message, errors);
    }

    public class Result<T> : Result
    {
        public T? Data { get; }

        private Result(T value, bool isSuccess, string message) : base(isSuccess, message)
        {
            Data = value;
        }

        private Result(bool isSuccess, string message , IEnumerable<string>? errors) : base(isSuccess, message , errors)
        {

        }

        public static Result<T> Success(T value , string message) => new Result<T>(value, true , message);
        public static new Result<T> Failure(string message, IEnumerable<string>? errors)
        {
            return new Result<T>(false, message, errors);
        }
    }
}
