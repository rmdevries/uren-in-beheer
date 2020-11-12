namespace UiB.Domain.WorkShifts
{
    public interface IWorkShiftRepository
    {
        WorkShift Insert(WorkShift workShift);
        WorkShift Update(WorkShift workShift);
    }
}