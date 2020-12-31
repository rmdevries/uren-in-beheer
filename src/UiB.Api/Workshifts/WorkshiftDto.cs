using System;
using UiB.Domain.Workshifts;

namespace UiB.Api.Workshifts
{
    public class WorkshiftDto
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public static implicit operator Workshift(WorkshiftDto workshift) =>
            new Workshift(workshift.Start, workshift.End);
    }
}