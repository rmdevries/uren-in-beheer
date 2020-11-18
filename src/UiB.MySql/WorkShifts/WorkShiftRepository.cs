using System;
using System.Data;
using Dapper;
using UiB.Domain.WorkShifts;

namespace UiB.MySql.WorkShifts
{
    public class WorkShiftRepository : IWorkShiftRepository
    {
        private readonly IDbConnection _conn;

        public WorkShiftRepository(IDbConnection connection)
        {
            _conn = connection;
        }

        public WorkShift Insert(WorkShift workShift)
        {
            try
            {
                using (_conn)
                {
                    _conn.Open();
                    string sql =
                        "INSERT INTO WorkShifts (Start, End) VALUES (@Start, @End);SELECT * FROM WorkShifts WHERE Id=(SELECT LAST_INSERT_ID());";
                    object param = new {Start = workShift.Start, End = workShift.End};
                    var insertedWorkShift = _conn.QuerySingle<WorkShift>(sql, param);
                    return insertedWorkShift;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public WorkShift Update(WorkShift workShift)
        {
            throw new NotImplementedException();
        }
    }
}