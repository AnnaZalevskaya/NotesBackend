using NotesPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesTests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly NotesDBContext _context;

        public TestCommandBase()
        {
            _context = NotesContextFactory.Create();
        }

        public void Dispose()
        {
            NotesContextFactory.Destroy(_context);
        }
    }
}
