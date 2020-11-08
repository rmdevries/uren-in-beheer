using FluentAssertions;
using System;
using System.Collections.Generic;
using UiB.Domain.WorkShifts;
using Xunit;

namespace UiB.Unit.Tests.WorkShifts
{
    public class WorkShiftTests
    {
        private static readonly DateTime Now = DateTime.Now;

        public static readonly IEnumerable<object[]> InvalidWorkShifts = new List<object[]>
        {
            new object[] {Now, Now},
            new object[] {Now.AddDays(1), Now}
        };

        [Fact]
        public void GivenValidWorkShift_WhenInitialize_InitializeWorkShift()
        {
            var start = DateTime.Now;
            var end = start.AddHours(1);
            var workShift = new WorkShift(start, end);

            workShift.Start.Should().Be(start);
            workShift.End.Should().Be(end);
        }

        [Theory]
        [MemberData(nameof(InvalidWorkShifts))]
        public void GivenInvalidWorkShift_WhenInitialize_ThenThrowInvalidWorkShiftException(DateTime start,
            DateTime end)
        {
            Assert.Throws<InvalidWorkShiftException>(() => new WorkShift(start, end));
        }
    }
}