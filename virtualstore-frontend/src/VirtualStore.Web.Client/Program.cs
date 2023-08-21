using Microsoft.AspNetCore.Authentication.Cookies;
using VirtualStore.Web.Client.Extensions;
using VirtualStore.Web.Core.Configurations.Mappers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddHttpClientCustom(builder.Configuration);

builder.Services.AddServicesDependencyInjection();

builder.Services.AddRepositoriesDependencyInjection();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<IObjectConverter, ObjectConverter>();

builder.Services.AddLogging();

builder.Services.AddCookieSchemeAuthentication();

WebApplication app = builder.Build();

app.UseEnvironmentIsDevelopment(app.Environment);

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
