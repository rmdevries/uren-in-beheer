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

        public int Insert(WorkShift workShift)
        {
            try
            {
                using (_conn)
                {
                    _conn.Open();
                    string sql =
                        "INSERT INTO WorkShifts (Start, End) VALUES (@Start, @End);SELECT LAST_INSERT_ID() FROM WorkShifts;";
                    object param = new {Start = workShift.Start, End = workShift.End};
                    var id = _conn.ExecuteScalar<int>(sql, param);
                    return id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}