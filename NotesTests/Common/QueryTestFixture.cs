using AutoMapper;
using NotesApplication.Common.Mappings;
using NotesApplication.Interfaces;
using NotesPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NotesTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public NotesDBContext dbContext;
        public IMapper mapper;

        public QueryTestFixture()
        {
            dbContext = NotesContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(INoteDBContext).Assembly));
            });
            mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            NotesContextFactory.Destroy(dbContext);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
