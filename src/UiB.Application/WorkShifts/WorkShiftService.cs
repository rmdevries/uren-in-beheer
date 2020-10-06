using UiB.Domain.WorkShifts;

namespace UiB.Application.WorkShifts
{
    public class WorkShiftService : IWorkShiftService
    {
        public WorkShift Create(WorkShift workShift)
        {
            return workShift;
        }
    }
}
