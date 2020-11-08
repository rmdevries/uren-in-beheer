using System;

namespace UiB.Domain.WorkShifts
{
    [Serializable]
    public class InvalidWorkShiftException : Exception
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public InvalidWorkShiftException()
        {
        }

        public InvalidWorkShiftException(string message) : base(message)
        {
        }

        public InvalidWorkShiftException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InvalidWorkShiftException(string message, DateTime start, DateTime end) : base(message)
        {
            Start = start;
            End = end;
        }
    }
}