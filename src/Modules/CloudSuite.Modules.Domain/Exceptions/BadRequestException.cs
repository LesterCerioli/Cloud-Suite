namespace CloudSuite.Modules.Domain.Exceptions
{
    public abstract class BadRequestException : ApplicationExtension
    {
        protected BadRequestException(string message)
            : base("Bad Request", message)
        {
        }
        
    }
}