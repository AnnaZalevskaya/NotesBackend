using Microsoft.EntityFrameworkCore;
using NotesApplication.Interfaces;
using NotesDomain;
using NotesPersistence.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
