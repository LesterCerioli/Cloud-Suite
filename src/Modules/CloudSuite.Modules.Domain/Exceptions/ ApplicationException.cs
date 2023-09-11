using System;
namespace CloudSuite.Modules.Domain.Exceptions
{
    public abstract class  ApplicationException : Exception
    {
        protected ApplicationException(string title, string message)
            : base(message) =>
            title = title;
        public string Title {get;}
        
    }
}