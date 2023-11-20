namespace CoursesApp.Infrastructure.Exceptions
{
    public class RepeatedUniqueIndexException: Exception
    {
        public RepeatedUniqueIndexException()
        {
        }

        public RepeatedUniqueIndexException(string message)
            : base(message)
        {
        }

        public RepeatedUniqueIndexException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
