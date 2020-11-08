﻿using UiB.Domain.Shared;

namespace UiB.Domain.WorkShifts
{
    public interface IWorkShiftService
    {
        public int Create(WorkShift workShift);
    }

    public class WorkShiftService : IWorkShiftService
    {
        private readonly IWorkShiftRepository _repository;

        public WorkShiftService(IWorkShiftRepository repository)
        {
            _repository = repository ?? throw new NoDatabaseException();
        }

        public int Create(WorkShift workShift)
        {
            return _repository.Insert(workShift);
        }
    }
}