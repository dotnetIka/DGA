using System;
namespace Infrastructure
{
    public class Result<T>
    {
        public bool Success { get; private set; }
        public int StatusCode { get; private set; } 
        public List<string> ErrorMessages { get; private set; }
        public T Data { get; private set; }

        private Result(bool success, int statusCode, T data, List<string> errorMessages)
        {
            Success = success;
            StatusCode = statusCode;
            Data = data;
            ErrorMessages = errorMessages ?? new List<string>();
        }

        public static Result<T> SuccessResult(T data = default)
        {
            return new Result<T>(true, 200, data, null);
        }

        public static Result<T> ErrorResult(int statusCode, string errorMessage)
        {
            var errorMessages = new List<string> { errorMessage };
            return new Result<T>(false, statusCode, default, errorMessages);
        }

        public Result<T> WithStatusCode(int statusCode)
        {
            StatusCode = statusCode;
            return this;
        }

        public Result<T> WithError(string errorMessage)
        {
            Success = false;
            ErrorMessages.Add(errorMessage);
            return this;
        }

        public Result<T> WithErrors(List<string> errorMessages)
        {
            Success = false;
            ErrorMessages.AddRange(errorMessages);
            return this;
        }
    }
}

