using UiB.Domain.WorkShifts;

namespace UiB.Api.WorkShifts
{
    public class WorkShiftService : IWorkShiftService
    {
        public WorkShift Create(WorkShift workShift)
        {
            return workShift;
        }
    }
}