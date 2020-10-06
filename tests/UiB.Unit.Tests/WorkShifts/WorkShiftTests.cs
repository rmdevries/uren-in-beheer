using FluentAssertions;
using System;
using System.Collections.Generic;
using UiB.Domain.WorkShifts;
using Xunit;

namespace UiB.Unit.Tests.WorkShifts
{
    public class WorkShiftTests
    {
        public static IEnumerable<object[]> InvalidWorkShifts => new List<object[]>
        {
            new object[] {new DateTime(2020, 01, 01, 01, 01, 01), new DateTime(2020, 01, 01, 01, 01, 01)},
            new object[] {new DateTime(2020, 02, 02, 02, 02, 02), new DateTime(2020, 01, 01, 01, 01, 01)}
        };

        [Fact]
        public void GivenValidWorkShift_WhenInitialize_ThenInitializeWorkShift()
        {
            var start = DateTime.Now;
            var end = DateTime.Now.AddHours(1);

            var workShift = new WorkShift(start, end);

            workShift.Start.Should().Be(start);
            workShift.End.Should().Be(end);
            workShift.Total.Should().Be(end.Subtract(start));
        }

        [Theory]
        [MemberData(nameof(InvalidWorkShifts))]
        public void GivenInvalidWorkShift_WhenInitialize_ThenThrowArgumentException(DateTime start, DateTime end)
        {
            Assert.Throws<ArgumentException>(() => new WorkShift(start, end));
        }
    }
}