using System;

namespace UiB.Domain.WorkShift
{
    public class WorkShift
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public WorkShift(DateTime start, DateTime end)
        {
            if(end <= start)
                throw new ArgumentException("Failed to create WorkShift, because start and end can't be the same");

            Start = start;
            End = end;
        }
    }
}
