using FluentAssertions;
using System;
using Moq;
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
            var expectedResult = 1;
            var start = DateTime.Now;
            var end = start.AddHours(1);
            var workShift = new WorkShift(start, end);

            var workShiftRepository = new Mock<IWorkShiftRepository>();
            workShiftRepository.Setup(repo => repo.Insert(workShift)).Returns(expectedResult);

            var workShiftService = new WorkShiftService(workShiftRepository.Object);

            var result = workShiftService.Create(workShift);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [ClassData(typeof(InvalidWorkShiftData))]
        public void GivenInValidWorkShift_WhenCreate_ThenThrowArgumentException(DateTime start, DateTime end)
        {
            var workShiftRepository = new Mock<IWorkShiftRepository>();
            var workShiftService = new WorkShiftService(workShiftRepository.Object);

            Assert.Throws<ArgumentException>(() => workShiftService.Create(new WorkShift(start, end)));
        }
    }
}