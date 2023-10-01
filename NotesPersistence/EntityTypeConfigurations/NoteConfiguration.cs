using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotesDomain;

namespace NotesPersistence.EntityTypeConfigurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id);
            builder.Property(note => note.Title).HasMaxLength(250);
        }
    }
}
