namespace CleanArchitectureTemplate.Infrastructure.Exceptions
{
    public class StringSetException : Exception
    {
        public StringSetException() {}
    
        public StringSetException(string errorMessage) : base(errorMessage) {}
    
    }
}