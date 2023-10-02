using System.Collections.Generic;

namespace NotesApplication.Notes.Queries.GetNoteList
{
    public class NoteListVm
    {
        public IList<NoteLookupDTO> Notes { get; set; }
    }
}
