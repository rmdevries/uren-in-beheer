using System;
using System.Collections.Generic;
using UiB.Domain.Shared;

namespace UiB.Domain.WorkShifts
{
    public interface IWorkShiftService
    {
        public WorkShift Create(WorkShift workShift);
        public WorkShift Edit(WorkShift workShift, DateTime start, DateTime end);
        public WorkShift Read(int id);
        public IEnumerable<WorkShift> Read(int page, int pageSize);
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

        public WorkShift Read(int id)
        {
            return _repository.Read(id);
        }

        public IEnumerable<WorkShift> Read(int page, int pageSize)
        {
            return _repository.Read(page, pageSize);
        }
    }
}