namespace VirtualStore.Web.Client.Extensions;

public static class WebApplicationExtension
{
    public static IApplicationBuilder UseEnvironmentIsDevelopment(this IApplicationBuilder app, IWebHostEnvironment environment)
    {
        if (!environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        return app;
    }
}