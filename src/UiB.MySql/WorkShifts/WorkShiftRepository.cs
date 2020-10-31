using UiB.Domain.WorkShifts;

namespace UiB.MySql.WorkShifts
{
    public class WorkShiftRepository : IWorkShiftRepository
    {
        public int Insert(WorkShift workShift)
        {
            return workShift.Id;
        }
    }
}