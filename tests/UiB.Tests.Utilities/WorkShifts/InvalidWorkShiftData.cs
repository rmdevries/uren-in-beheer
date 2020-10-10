using System;
using System.Collections;
using System.Collections.Generic;

namespace UiB.Tests.Utilities.WorkShifts
{
    public class InvalidWorkShiftData : IEnumerable<object[]>
    {
        private readonly IEnumerable<object[]> _data = new List<object[]>
        {
            new object[] { new DateTime(2020, 01, 01, 01, 01, 01), new DateTime(2020, 01, 01, 01, 01, 01) },
            new object[] { new DateTime(2020, 02, 02, 02, 02, 02), new DateTime(2020, 01, 01, 01, 01, 01) }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
