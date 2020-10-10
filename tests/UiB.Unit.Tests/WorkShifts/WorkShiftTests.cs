using System;
using UiB.Domain.WorkShifts;
using UiB.Tests.Utilities.WorkShifts;
using Xunit;

namespace UiB.Unit.Tests.WorkShifts
{
    public class WorkShiftTests
    {
        [Fact]
        public void GivenValidWorkShift_WhenInitialize_ThenInitializeWorkShift()
        {
            var start = DateTime.Now;
            var end = DateTime.Now.AddHours(1);
            new WorkShift(start, end);
        }

        [Theory]
        [ClassData(typeof(InvalidWorkShiftData))]
        public void GivenInvalidWorkShift_WhenInitialize_ThenThrowArgumentException(DateTime start, DateTime end)
        {
            Assert.Throws<ArgumentException>(() => new WorkShift(start, end));
        }
    }
}