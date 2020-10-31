using UiB.Domain.WorkShifts;

namespace UiB.MySql.WorkShifts
{
    public class WorkShiftRepository : IWorkShiftRepository
    {
        public WorkShift Insert(WorkShift workShift)
        {
            return workShift;
        }
    }
}