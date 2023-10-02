using System;
using MediatR;

namespace NotesApplication.Notes.Queries.GetNoteList
{
    public class GetNoteListQuery :IRequest<NoteListVm>
    {
        public Guid UserId { get; set; }    
    }
}
