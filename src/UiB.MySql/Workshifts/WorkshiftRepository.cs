using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using UiB.Domain.Workshifts;

namespace UiB.MySql.Workshifts
{
    public class WorkshiftRepository : IWorkshiftRepository
    {
        private readonly IDbConnection _conn;

        public WorkshiftRepository(IDbConnection connection)
        {
            _conn = connection;
        }

        public Workshift Insert(Workshift workshift)
        {
            try
            {
                using (_conn)
                {
                    _conn.Open();
                    string sql = "INSERT INTO Workshifts (Start, End) VALUES (@Start, @End);SELECT LAST_INSERT_ID();";
                    var param = new {Start = workshift.Start, End = workshift.End};
                    var insertedId = _conn.ExecuteScalar<int>(sql, param);
                    var insertedWorkshift = Read(insertedId);
                    return insertedWorkshift;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public Workshift Update(Workshift workshift)
        {
            throw new NotImplementedException();
        }

        public Workshift Read(int id)
        {
            try
            {
                string sql = "SELECT * FROM Workshifts WHERE Id = @Id";
                var param = new {Id = id};

                var workshift = _conn.QueryFirst<WorkshiftEntity>(sql, param);
                return workshift;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public IEnumerable<Workshift> Read(int page, int pageSize)
        {
            try
            {
                string sql = "SELECT * FROM Workshifts ORDER BY Id DESC LIMIT @Offset, @Size";
                var param = new {Offset = page * pageSize, Size = pageSize};

                var workshifts = _conn.Query<WorkshiftEntity>(sql, param);
                return workshifts.Select(shift => (Workshift) shift);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}