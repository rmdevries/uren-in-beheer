using System;
using FluentAssertions;
using UiB.Application;
using UiB.Domain.WorkShift;
using Xunit;

namespace UiB.Unit.Tests.WorkShift
{
    public class WorkShiftServiceTests
    {
        [Fact]
        public void GivenValidWorkShift_WhenCreate_ThenReturnWorkShift()
        {
            DateTime start = DateTime.Now;
            DateTime end = start.AddHours(1);
            Domain.WorkShift.WorkShift workShift = new Domain.WorkShift.WorkShift(start, end);
            IWorkShiftService workShiftService = new WorkShiftService();

            var result = workShiftService.Create(workShift);

            result.Start.Should().Be(start);
            result.End.Should().Be(end);
            result.Total.Should().Be(end.Subtract(start));
        }
    }
}