using MediatR;
using Microsoft.EntityFrameworkCore;
using NotesApplication.Interfaces;

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

            }

            return Unit.Value;
        }
    }
}
