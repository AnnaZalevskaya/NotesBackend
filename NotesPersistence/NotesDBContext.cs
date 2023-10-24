using Microsoft.EntityFrameworkCore;
using NotesApplication.Interfaces;
using NotesDomain;
using NotesPersistence.EntityTypeConfigurations;

namespace NotesPersistence
{
    public class NotesDBContext : DbContext, INoteDBContext
    {
        public DbSet<Note> Notes { get; set; }

        public NotesDBContext(DbContextOptions<NotesDBContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
