using AutoMapper;
using NotesApplication.Notes.Queries.GetNoteDetails;
using NotesPersistence;
using NotesTests.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NotesTests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteDetailsQueryHandlerTest
    {
        private readonly NotesDBContext _context;
        private readonly IMapper _mapper;

        public GetNoteDetailsQueryHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.dbContext;
            _mapper = fixture.mapper;
        }

        [Fact]
        public async Task GetNoteDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetNoteDetailsQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetNoteDetailsQuery
                {
                    UserId = NotesContextFactory.UserBId,
                    Id = Guid.Parse("6685E9D3-F059-4AE8-9B70-C6436BF4F5A6")
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<NoteDetailsVm>();
            result.Title.ShouldBe("TitleB");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
