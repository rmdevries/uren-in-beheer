using System;
using UiB.Domain.WorkShifts;

namespace UiB.MySql.WorkShifts
{
    public class WorkShiftEntity
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public static implicit operator WorkShift(WorkShiftEntity entity) =>
            new WorkShift(entity.Id, entity.Start, entity.End);
    }
}