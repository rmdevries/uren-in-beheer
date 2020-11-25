using System;

namespace UiB.Domain.WorkShifts
{
    public class WorkShift
    {
        public int Id { get; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public WorkShift(int id, DateTime start, DateTime end)
        {
            if (end <= start)
                throw new InvalidWorkShiftException("Unable to initialize WorkShift due to invalid time period.", start,
                    end);

            Id = id;
            Start = start;
            End = end;
        }

        public WorkShift(DateTime start, DateTime end)
        {
            if (end <= start)
                throw new InvalidWorkShiftException("Unable to initialize WorkShift due to invalid time period.", start,
                    end);

            Start = start;
            End = end;
        }

        public void Update(DateTime start, DateTime end)
        {
            if (end <= start)
                throw new InvalidWorkShiftException("Unable to initialize WorkShift due to invalid time period.", start,
                    end);

            Start = start;
            End = end;
        }
    }
}
