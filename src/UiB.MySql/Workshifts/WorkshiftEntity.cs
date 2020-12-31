using System;
using UiB.Domain.Workshifts;

namespace UiB.MySql.Workshifts
{
    public class WorkshiftEntity
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public static implicit operator Workshift(WorkshiftEntity entity) =>
            new Workshift(entity.Id, entity.Start, entity.End);
    }
}