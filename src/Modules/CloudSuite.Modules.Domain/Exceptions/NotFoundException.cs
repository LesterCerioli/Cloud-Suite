namespace CloudSuite.Modules.Domain.Exceptions
{
    public abstract class NotFoundException : ApplicationExtension
    {
        protected NotFoundException(string message)
            : base("Not Found", message)
        {
        }
        
    }
}