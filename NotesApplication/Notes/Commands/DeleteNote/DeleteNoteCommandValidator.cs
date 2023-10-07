using FluentValidation;

namespace NotesApplication.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidator()
        {
            RuleFor(note => note.Id)
                .NotEqual(Guid.Empty);
            RuleFor(note => note.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}
