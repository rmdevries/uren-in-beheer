using System;
using System.Collections.Generic;
using FluentAssertions;
using UiB.Application.WorkShifts;
using UiB.Domain.WorkShifts;
using Xunit;

namespace UiB.Unit.Tests.WorkShifts
{
    public class WorkShiftServiceTests
    {
        public static IEnumerable<object[]> InvalidWorkShifts => new List<object[]>
        {
            new object[] {new DateTime(2020, 01, 01, 01, 01, 01), new DateTime(2020, 01, 01, 01, 01, 01)},
            new object[] {new DateTime(2020, 02, 02, 02, 02, 02), new DateTime(2020, 01, 01, 01, 01, 01)}
        };

        [Fact]
        public void GivenValidWorkShift_WhenCreate_ThenReturnWorkShift()
        {
            DateTime start = DateTime.Now;
            DateTime end = start.AddHours(1);
            WorkShift workShift = new WorkShift(start, end);
            IWorkShiftService workShiftService = new WorkShiftService();

            var result = workShiftService.Create(workShift);

            result.Start.Should().Be(start);
            result.End.Should().Be(end);
            result.Total.Should().Be(end.Subtract(start));
        }

        [Theory]
        [MemberData(nameof(InvalidWorkShifts))]
        public void GivenInValidWorkShift_WhenCreate_ThenThrowArgumentException(DateTime start, DateTime end)
        {
            Assert.Throws<ArgumentException>(() => new WorkShift(start, end));
        }
    }
}