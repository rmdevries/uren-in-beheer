using System;

namespace UiB.Domain.Workshifts
{
    public class Workshift
    {
        public int Id { get; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public Workshift(int id, DateTime start, DateTime end)
        {
            if (end <= start)
                throw new InvalidWorkshiftException("Unable to initialize Workshift due to invalid time period.", start,
                    end);

            Id = id;
            Start = start;
            End = end;
        }

        public Workshift(DateTime start, DateTime end)
        {
            if (end <= start)
                throw new InvalidWorkshiftException("Unable to initialize Workshift due to invalid time period.", start,
                    end);

            Start = start;
            End = end;
        }

        public void Update(DateTime start, DateTime end)
        {
            if (end <= start)
                throw new InvalidWorkshiftException("Unable to initialize Workshift due to invalid time period.", start,
                    end);

            Start = start;
            End = end;
        }
    }
}
