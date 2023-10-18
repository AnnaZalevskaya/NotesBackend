using AutoMapper;
using NotesApplication.Notes.Queries.GetNoteList;
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
    public class GetNoteListQueryHandlerTest
    {
        private readonly NotesDBContext _context;
        private readonly IMapper _mapper;
        
        public GetNoteListQueryHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.dbContext;
            _mapper = fixture.mapper;   
        }

        [Fact]
        public async void GetNoteListQueryHandler_Success()
        {
            //Arrange
            var handler = new GetNoteListQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetNoteListQuery
                {
                    UserId = NotesContextFactory.UserBId
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<NoteListVm>();
            result.Notes.Count.ShouldBe(2);
        }
    }
}
