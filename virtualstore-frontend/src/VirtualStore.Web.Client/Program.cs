using VirtualStore.Web.Client.Extensions;
using VirtualStore.Web.Core.Configurations.Mappers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClientCustom(builder.Configuration);

builder.Services.AddServicesDependencyInjection();

builder.Services.AddRepositoriesDependencyInjection();

builder.Services.AddSingleton<IObjectConverter, ObjectConverter>();

WebApplication app = builder.Build();

app.UseEnvironmentIsDevelopment(app.Environment);

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
