using FluentAssertions;
using Moq;
using System;
using UiB.Domain.Shared;
using UiB.Domain.WorkShifts;
using Xunit;

namespace UiB.Unit.Tests.WorkShifts
{
    public class WorkShiftServiceTests
    {
        [Fact]
        public void GivenNoRepository_WhenInitialize_ThenThrowNoDatabaseException()
        {
            Assert.Throws<NoDatabaseException>(() => new WorkShiftService(null));
        }

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
    }
}