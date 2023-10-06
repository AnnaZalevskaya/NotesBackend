using MediatR;
using NotesApplication.Common.Exceptions;
using NotesApplication.Interfaces;
using NotesDomain;

namespace NotesApplication.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequest<DeleteNoteCommand>
    {
        private readonly INoteDBContext _dbContext;

        public DeleteNoteCommandHandler(INoteDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            _dbContext.Notes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
