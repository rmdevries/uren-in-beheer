using System;
using System.Collections.Generic;
using FluentAssertions;
using UiB.Domain.Workshifts;
using Xunit;

namespace UiB.Unit.Tests.Workshifts
{
    public class WorkshiftTests
    {
        private static readonly DateTime Now = DateTime.Now;

        public static readonly IEnumerable<object[]> InvalidWorkshifts = new List<object[]>
        {
            new object[] {Now, Now},
            new object[] {Now.AddDays(1), Now}
        };

        [Fact]
        public void GivenValidWorkshift_WhenInitialize_InitializeWorkshift()
        {
            var start = DateTime.Now;
            var end = start.AddHours(1);
            var workshift = new Workshift(start, end);

            workshift.Start.Should().Be(start);
            workshift.End.Should().Be(end);
        }

        [Theory]
        [MemberData(nameof(InvalidWorkshifts))]
        public void GivenInvalidWorkshift_WhenInitialize_ThenThrowInvalidWorkshiftException(DateTime start,
            DateTime end)
        {
            Assert.Throws<InvalidWorkshiftException>(() => new Workshift(start, end));
        }
    }
}