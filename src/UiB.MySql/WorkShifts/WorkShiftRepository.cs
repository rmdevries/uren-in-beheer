using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                    string sql = "INSERT INTO WorkShifts (Start, End) VALUES (@Start, @End);SELECT LAST_INSERT_ID();";
                    var param = new {Start = workShift.Start, End = workShift.End};
                    var insertedId = _conn.ExecuteScalar<int>(sql, param);
                    var insertedWorkShift = Read(insertedId);
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

        public WorkShift Read(int id)
        {
            try
            {
                string sql = "SELECT * FROM WorkShifts WHERE Id = @Id";
                var param = new {Id = id};

                var workShift = _conn.QueryFirst<WorkShiftEntity>(sql, param);
                return workShift;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public IEnumerable<WorkShift> Read(int page, int pageSize)
        {
            try
            {
                string sql = "SELECT * FROM WorkShifts ORDER BY Id DESC LIMIT @Offset, @Size";
                var param = new {Offset = page * pageSize, Size = pageSize};

                var workShifts = _conn.Query<WorkShiftEntity>(sql, param);
                return workShifts.Select(shift => (WorkShift) shift);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}