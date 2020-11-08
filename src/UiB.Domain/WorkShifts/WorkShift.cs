using System;

namespace UiB.Domain.WorkShifts
{
    public class WorkShift
    {
        public int Id { get; }
        public DateTime Start { get; }
        public DateTime End { get; }

        public WorkShift(DateTime start, DateTime end)
        {
            if (end <= start)
                throw new InvalidWorkShiftException("Unable to initialize WorkShift due to invalid time period.", start,
                    end);

            Start = start;
            End = end;
        }
    }
}
