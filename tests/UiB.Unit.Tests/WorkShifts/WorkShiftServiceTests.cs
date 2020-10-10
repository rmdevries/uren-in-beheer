using FluentAssertions;
using System;
using UiB.Api.WorkShifts;
using UiB.Domain.WorkShifts;
using UiB.Tests.Utilities.WorkShifts;
using Xunit;

namespace UiB.Unit.Tests.WorkShifts
{
    public class WorkShiftServiceTests
    {
        [Fact]
        public void GivenValidWorkShift_WhenCreate_ThenReturnWorkShift()
        {
            var start = DateTime.Now;
            var end = start.AddHours(1);
            var workShift = new WorkShift(start, end);
            IWorkShiftService workShiftService = new WorkShiftService();

            var result = workShiftService.Create(workShift);

            result.Start.Should().Be(start);
            result.End.Should().Be(end);
            result.Total.Should().Be(end.Subtract(start));
        }

        [Theory]
        [ClassData(typeof(InvalidWorkShiftData))]
        public void GivenInValidWorkShift_WhenCreate_ThenThrowArgumentException(DateTime start, DateTime end)
        {
            Assert.Throws<ArgumentException>(() => new WorkShift(start, end));
        }
    }
}