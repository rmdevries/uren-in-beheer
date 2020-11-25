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
        private readonly Mock<IWorkShiftRepository> _repository;
        private readonly IWorkShiftService _service;

        private readonly WorkShift _validWorkShift;

        public WorkShiftServiceTests()
        {
            _repository = new Mock<IWorkShiftRepository>();
            _service = new WorkShiftService(_repository.Object);

            _validWorkShift = new WorkShift(5, DateTime.Now, DateTime.Now.AddDays(1));
        }

        [Fact]
        public void GivenNoRepository_WhenInitialize_ThenThrowNoDatabaseException()
        {
            Assert.Throws<NoDatabaseException>(() => new WorkShiftService(null));
        }

        [Fact]
        public void GivenValidWorkShift_WhenCreate_ThenReturnInsertedWorkShift()
        {
            _repository.Setup(repo => repo.Insert(_validWorkShift)).Returns(_validWorkShift);

            var result = _service.Create(_validWorkShift);

            result.Should().Be(_validWorkShift);
        }

        [Fact]
        public void GivenPageAndPageSize_WhenRead_ThenReturnWorkShifts()
        {
            var workShifts = new[]
            {
                _validWorkShift,
                _validWorkShift,
                _validWorkShift
            };

            int page = 2;
            int pageSize = 10;

            _repository.Setup(repo => repo.Read(page, pageSize)).Returns(workShifts);

            var result = _service.Read(page, pageSize);

            result.Should().BeSameAs(workShifts);
        }

        [Fact]
        public void GivenWorkShiftId_WhenRead_ThenReturnSingleWorkShift()
        {
            _repository.Setup(repo => repo.Read(_validWorkShift.Id)).Returns(_validWorkShift);

            var result = _service.Read(_validWorkShift.Id);

            result.Should().BeSameAs(_validWorkShift);
        }

        [Fact]
        public void GivenValidWorkShift_WhenEdit_ThenReturnEditedWorkShift()
        {
            var editedStart = DateTime.Now.AddDays(1);
            var editedEnd = editedStart.AddHours(1);
            var editedWorkShift = new WorkShift(editedStart, editedEnd);

            _repository.Setup(repo => repo.Update(_validWorkShift)).Returns(editedWorkShift);

            var result = _service.Edit(_validWorkShift, editedStart, editedEnd);

            result.Start.Should().Be(editedStart);
            result.End.Should().Be(editedEnd);
        }
    }
}