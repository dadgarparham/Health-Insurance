namespace Health_Insurance.Api.Controllers.WebCore;
public static class ApplicationServiceCollectionExtensions
{
    public static void ConfigureCors(this IApplicationBuilder app, IConfiguration configuration)
    {
        var allowedOrigins = configuration.GetSection("AllowedOrigins").Get<List<string>>();
        app.UseCors(policyBuilder =>
        {
            policyBuilder
                .SetIsOriginAllowed(x => allowedOrigins == null || !allowedOrigins.Any()
                || allowedOrigins.Any(allowedOrigin => x.IndexOf(allowedOrigin, 
                StringComparison.OrdinalIgnoreCase) != -1))
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .SetPreflightMaxAge(TimeSpan.FromDays(30));
        });
    }
}

