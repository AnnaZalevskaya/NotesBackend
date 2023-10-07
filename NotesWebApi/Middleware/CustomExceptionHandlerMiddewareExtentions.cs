using Microsoft.AspNetCore.Builder;

namespace NotesWebApi.Middleware
{
    public static class CustomExceptionHandlerMiddewareExtentions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddeware>();
        }
    }
}
