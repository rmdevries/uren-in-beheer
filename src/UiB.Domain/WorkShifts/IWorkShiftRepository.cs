using System.Collections.Generic;

namespace UiB.Domain.WorkShifts
{
    public interface IWorkShiftRepository
    {
        WorkShift Insert(WorkShift workShift);
        WorkShift Update(WorkShift workShift);
        WorkShift Read(int id);
        IEnumerable<WorkShift> Read(int page, int pageSize);
    }
}