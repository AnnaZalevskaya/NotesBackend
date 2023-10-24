using Microsoft.EntityFrameworkCore;
using NotesDomain;

namespace NotesApplication.Interfaces
{
    public interface INoteDBContext
    {
        DbSet<Note> Notes { get; set; }
        Task<int> SaveChangesAsync (CancellationToken cancellationToken);
    }
}
