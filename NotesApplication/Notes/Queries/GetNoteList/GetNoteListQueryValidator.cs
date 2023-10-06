using FluentValidation;

namespace NotesApplication.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryValidator :AbstractValidator<GetNoteListQuery>
    {
        public GetNoteListQueryValidator()
        {
            RuleFor(note => note.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}
