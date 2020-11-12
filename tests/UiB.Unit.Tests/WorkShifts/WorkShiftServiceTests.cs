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
        public void GivenValidWorkShift_WhenCreate_ThenReturnInsertedWorkShift()
        {
            var start = DateTime.Now;
            var end = start.AddHours(1);
            var workShift = new WorkShift(start, end);

            var workShiftRepository = new Mock<IWorkShiftRepository>();
            workShiftRepository.Setup(repo => repo.Insert(workShift)).Returns(workShift);

            IWorkShiftService workShiftService = new WorkShiftService(workShiftRepository.Object);

            var result = workShiftService.Create(workShift);

            result.Should().Be(workShift);
        }

        [Fact]
        public void GivenValidWorkShift_WhenEdit_ThenReturnEditedWorkShift()
        {
            var start = DateTime.Now;
            var end = start.AddHours(1);
            var workShift = new WorkShift(start, end);

            var editedStart = DateTime.Now.AddDays(1);
            var editedEnd = editedStart.AddHours(1);
            var editedWorkShift = new WorkShift(start, end);

            var workShiftRepository = new Mock<IWorkShiftRepository>();
            workShiftRepository.Setup(repo => repo.Update(workShift)).Returns(editedWorkShift);

            IWorkShiftService workShiftService = new WorkShiftService(workShiftRepository.Object);

            var result = workShiftService.Edit(workShift, editedStart, editedEnd);

            result.Should().Be(editedWorkShift);
        }
    }
}