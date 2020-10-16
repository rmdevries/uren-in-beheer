namespace UiB.Domain.WorkShifts
{
    public interface IWorkShiftService
    {
        public WorkShift Create(WorkShift workShift);
    }

    public class WorkShiftService : IWorkShiftService
    {
        private readonly IWorkShiftRepository _repo;

        public WorkShiftService(IWorkShiftRepository repo)
        {
            _repo = repo;
        }

        public WorkShift Create(WorkShift workShift)
        {
            return _repo.Insert(workShift);
        }
    }
}