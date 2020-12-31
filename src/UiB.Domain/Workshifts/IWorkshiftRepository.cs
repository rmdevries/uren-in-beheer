using System.Collections.Generic;

namespace UiB.Domain.Workshifts
{
    public interface IWorkshiftRepository
    {
        Workshift Insert(Workshift workshift);
        Workshift Update(Workshift workshift);
        Workshift Read(int id);
        IEnumerable<Workshift> Read(int page, int pageSize);
    }
}