using VirtualStore.Identity.API.Extensions;
using VirtualStore.Identity.Core.Configurations.Mappers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddSecrets();

builder.Services.AddLowerCaseRouting();

builder.Services.AddControllers();

builder.Services.AddServicesDependencyInjection();

builder.Services.AddRepositoriesDependencyInjection();

builder.Services.AddAPIVersioningCustomSettings(builder.Configuration);

builder.Services.AddSwaggerCustomSettings(builder.Configuration);

builder.Services.AddCorsCustomSettings(builder.Configuration);

builder.Services.AddAuthentication(builder.Configuration);

builder.Services.AddAuthorization();

builder.Services.AddAuthenticationSwaggerJwtBearer();

builder.Services.AddSingleton<IObjectConverter, ObjectConverter>();

WebApplication app = builder.Build();

app.UseCors();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseHandleException();

app.UseSwaggerCustomSettings();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
