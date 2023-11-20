using FluentValidation.Results;

namespace Common.Services
{
    public class ServiceResult
    {
        public string ErrorMessage { get; private set; }
        public Type? ExceptionType { get; private set; }
        public object? Data { get; private set; }

        public ServiceResult(Exception exception)
        {
            ErrorMessage = exception.Message;
            ExceptionType = exception.GetType();
            Data = null;
        }

        public ServiceResult(object data)
        {
            ErrorMessage = "";
            ExceptionType = null;
            Data = data;
        }

        public ServiceResult(IList<ValidationFailure> errors)
        {
            ErrorMessage = "Entity validation errors encountered";
            ExceptionType = new InvalidDataException().GetType();
            Data = errors;
        }
    }
}
