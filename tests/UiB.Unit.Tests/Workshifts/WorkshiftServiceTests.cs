using System;
using FluentAssertions;
using Moq;
using UiB.Domain.Shared;
using UiB.Domain.Workshifts;
using Xunit;

namespace UiB.Unit.Tests.Workshifts
{
    public class WorkshiftServiceTests
    {
        private readonly Mock<IWorkshiftRepository> _repository;
        private readonly IWorkshiftService _service;

        private readonly Workshift _validWorkshift;

        public WorkshiftServiceTests()
        {
            _repository = new Mock<IWorkshiftRepository>();
            _service = new WorkshiftService(_repository.Object);

            _validWorkshift = new Workshift(5, DateTime.Now, DateTime.Now.AddDays(1));
        }

        [Fact]
        public void GivenNoRepository_WhenInitialize_ThenThrowNoDatabaseException()
        {
            Assert.Throws<NoDatabaseException>(() => new WorkshiftService(null));
        }

        [Fact]
        public void GivenValidWorkshift_WhenCreate_ThenReturnInsertedWorkshift()
        {
            _repository.Setup(repo => repo.Insert(_validWorkshift)).Returns(_validWorkshift);

            var result = _service.Create(_validWorkshift);

            result.Should().Be(_validWorkshift);
        }

        [Fact]
        public void GivenPageAndPageSize_WhenRead_ThenReturnWorkshifts()
        {
            var workshifts = new[]
            {
                _validWorkshift,
                _validWorkshift,
                _validWorkshift
            };

            int page = 2;
            int pageSize = 10;

            _repository.Setup(repo => repo.Read(page, pageSize)).Returns(workshifts);

            var result = _service.Read(page, pageSize);

            result.Should().BeSameAs(workshifts);
        }

        [Fact]
        public void GivenWorkshiftId_WhenRead_ThenReturnSingleWorkshift()
        {
            _repository.Setup(repo => repo.Read(_validWorkshift.Id)).Returns(_validWorkshift);

            var result = _service.Read(_validWorkshift.Id);

            result.Should().BeSameAs(_validWorkshift);
        }

        [Fact]
        public void GivenValidWorkshift_WhenEdit_ThenReturnEditedWorkshift()
        {
            var editedStart = DateTime.Now.AddDays(1);
            var editedEnd = editedStart.AddHours(1);
            var editedWorkshift = new Workshift(editedStart, editedEnd);

            _repository.Setup(repo => repo.Update(_validWorkshift)).Returns(editedWorkshift);

            var result = _service.Edit(_validWorkshift, editedStart, editedEnd);

            result.Start.Should().Be(editedStart);
            result.End.Should().Be(editedEnd);
        }
    }
}