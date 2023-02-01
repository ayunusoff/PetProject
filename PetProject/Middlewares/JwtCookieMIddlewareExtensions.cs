namespace PetProject.Middlewares
{
    public static class JwtCookieMIddlewareExtensions
    {
        public static IApplicationBuilder UseJwtCookieMIddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<JwtCookieMIddleware>();
    }
    }
}