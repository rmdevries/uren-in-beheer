using System;
using UiB.Domain.Shared;

namespace UiB.Domain.WorkShifts
{
    public interface IWorkShiftService
    {
        public WorkShift Create(WorkShift workShift);
        public WorkShift Edit(WorkShift workShift, DateTime start, DateTime end);
    }

    public class WorkShiftService : IWorkShiftService
    {
        private readonly IWorkShiftRepository _repository;

        public WorkShiftService(IWorkShiftRepository repository)
        {
            _repository = repository ?? throw new NoDatabaseException();
        }

        public WorkShift Create(WorkShift workShift)
        {
            return _repository.Insert(workShift);
        }

        public WorkShift Edit(WorkShift workShift, DateTime start, DateTime end)
        {
            workShift.Update(start, end);
            return _repository.Update(workShift);
        }
    }
}