using Azure.Identity;
using Tarker.Booking.Api.DIConfigurations;
using Tarker.Booking.Application.DIConfigurations;
using Tarker.Booking.Common.DIConfigurations;
using Tarker.Booking.External.DIConfigurations;
using Tarker.Booking.Persistence.DIConfigurations;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string? keyVaultUrl = builder.Configuration["KeyVault:Url"] ?? string.Empty;
if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "local")
{
    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), new ClientSecretCredential(Environment.GetEnvironmentVariable("tenantId"),
        Environment.GetEnvironmentVariable("clientId"), Environment.GetEnvironmentVariable("clientSecret")));
}
else
    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), new DefaultAzureCredential());

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

WebApplication app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
