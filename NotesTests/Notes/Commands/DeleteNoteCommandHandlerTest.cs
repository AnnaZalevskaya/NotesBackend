using NotesApplication.Common.Exceptions;
using NotesApplication.Notes.Commands.CreateNote;
using NotesApplication.Notes.Commands.DeleteNote;
using NotesTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NotesTests.Notes.Commands
{
    public class DeleteNoteCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task DeleteNoteCommandHandler_Succed()
        {
            //Arrange
            var handler = new DeleteNoteCommandHandler(_context);

            //Act
            await handler.Handle(new DeleteNoteCommand
            {
                Id = NotesContextFactory.NoteIdForDelete,
                UserId = NotesContextFactory.UserAId
            }, CancellationToken.None);

            //Assert
            Assert.Null(_context.Notes.SingleOrDefault(note =>
            note.Id == NotesContextFactory.NoteIdForDelete));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteNoteCommandHandler(_context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteNoteCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = NotesContextFactory.UserAId
                    }, CancellationToken.None));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongUserId()
        {
            //Arrange
            var deleteHandler = new DeleteNoteCommandHandler(_context);
            var createHandler = new CreateNoteCommandHandler(_context);
            var noteId = await createHandler.Handle(
                new CreateNoteCommand
                {
                    Title = "NoteTitle",
                    UserId = NotesContextFactory.UserAId,
                    Details = "NoteDetails"
                }, CancellationToken.None);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteNoteCommand
                    {
                        Id = noteId,
                        UserId = NotesContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}
