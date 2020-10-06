using UiB.Domain.WorkShift;

namespace UiB.Application
{
    public class WorkShiftService : IWorkShiftService
    {
        public WorkShift Create(WorkShift workShift)
        {
            return workShift;
        }
    }
}
