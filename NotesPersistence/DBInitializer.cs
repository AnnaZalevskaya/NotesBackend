namespace NotesPersistence
{
    public class DBInitializer
    {
        public static void Inizialize(NotesDBContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
