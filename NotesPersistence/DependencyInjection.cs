using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotesApplication.Interfaces;

namespace NotesPersistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, 
            IConfiguration configuration)
        {
            var connectionString = configuration["DBConnection"];
            services.AddDbContext<NotesDBContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<INoteDBContext>(provider =>
            provider.GetService<NotesDBContext>());

            return services;
        }   
    }
}
