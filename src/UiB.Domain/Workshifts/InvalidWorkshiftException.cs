using System;

namespace UiB.Domain.Workshifts
{
    [Serializable]
    public class InvalidWorkshiftException : Exception
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public InvalidWorkshiftException()
        {
        }

        public InvalidWorkshiftException(string message) : base(message)
        {
        }

        public InvalidWorkshiftException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InvalidWorkshiftException(string message, DateTime start, DateTime end) : base(message)
        {
            Start = start;
            End = end;
        }
    }
}