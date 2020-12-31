using System;
using System.Collections.Generic;
using UiB.Domain.Shared;

namespace UiB.Domain.Workshifts
{
    public interface IWorkshiftService
    {
        public Workshift Create(Workshift workshift);
        public Workshift Edit(Workshift workshift, DateTime start, DateTime end);
        public Workshift Read(int id);
        public IEnumerable<Workshift> Read(int page, int pageSize);
    }

    public class WorkshiftService : IWorkshiftService
    {
        private readonly IWorkshiftRepository _repository;

        public WorkshiftService(IWorkshiftRepository repository)
        {
            _repository = repository ?? throw new NoDatabaseException();
        }

        public Workshift Create(Workshift workshift)
        {
            return _repository.Insert(workshift);
        }

        public Workshift Edit(Workshift workshift, DateTime start, DateTime end)
        {
            workshift.Update(start, end);
            return _repository.Update(workshift);
        }

        public Workshift Read(int id)
        {
            return _repository.Read(id);
        }

        public IEnumerable<Workshift> Read(int page, int pageSize)
        {
            return _repository.Read(page, pageSize);
        }
    }
}