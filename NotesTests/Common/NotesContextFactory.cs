using Microsoft.EntityFrameworkCore;
using NotesDomain;
using NotesPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesTests.Common
{
    public class NotesContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid NoteIdForDelete = Guid.NewGuid();
        public static Guid NoteIdForUpdate = Guid.NewGuid();   
        
        public static NotesDBContext Create()
        {
            var options = new DbContextOptionsBuilder<NotesDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var dbContext = new NotesDBContext(options);
            dbContext.Database.EnsureCreated();
            dbContext.Notes.AddRange(
                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "DetailsA",
                    EditDate = null,
                    Id = Guid.Parse("BF6EEF5B-BC05-4BA7-9F79-F05394F58D17"),
                    Title = "TitleA",
                    UserId = UserAId,
                },
                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "DetailsB",
                    EditDate = null,
                    Id = Guid.Parse("6685E9D3-F059-4AE8-9B70-C6436BF4F5A6"),
                    Title = "TitleB",
                    UserId = UserBId,
                },
                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "DetailsDel",
                    EditDate = null,
                    Id = NoteIdForDelete,
                    Title = "TitleDel",
                    UserId = UserAId,
                },
                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "DetailsUpd",
                    EditDate = null,
                    Id = NoteIdForUpdate,
                    Title = "TitleUpd",
                    UserId = UserBId,
                }
            );
            dbContext.SaveChanges();

            return dbContext;
        }

        public static void Destroy(NotesDBContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
