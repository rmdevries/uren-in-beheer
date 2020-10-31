using System;
using UiB.Domain.WorkShifts;

namespace UiB.Api.WorkShifts
{
    public class WorkShiftDto
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public static implicit operator WorkShift(WorkShiftDto workShift) =>
            new WorkShift(workShift.Start, workShift.End);
    }
}