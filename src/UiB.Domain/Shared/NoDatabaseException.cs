using System;

namespace UiB.Domain.Shared
{
    public class NoDatabaseException : Exception
    {
        public NoDatabaseException()
        {
        }

        public NoDatabaseException(string message) : base(message)
        {
        }

        public NoDatabaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}