using MediatR;
using Microsoft.EntityFrameworkCore;
using NotesApplication.CommonMappings.Exceptions;
using NotesApplication.Interfaces;
using NotesDomain;

namespace NotesApplication.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequest<UpdateNoteCommand>
    {
        private readonly INoteDBContext _dbContext;

        public UpdateNoteCommandHandler(INoteDBContext dbContext) => 
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateNoteCommand request, 
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes
                .FirstOrDefaultAsync(n => n.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                new NotFoundException(nameof(Note), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
