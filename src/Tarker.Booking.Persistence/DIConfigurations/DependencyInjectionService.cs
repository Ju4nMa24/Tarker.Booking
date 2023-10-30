using Azure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.AlwaysEncrypted.AzureKeyVaultProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Application.DataBase;
using Tarker.Booking.Persistence.Database;

namespace Tarker.Booking.Persistence.DIConfigurations
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseService>(options => options.UseSqlServer(configuration["SQLConnectionString"]));
            #region Add services to the container
            services.AddScoped<IDataBaseService, DataBaseService>();
            #endregion
            #region Configuration to Always Encrypter
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "local")
            {
                SqlConnection.RegisterColumnEncryptionKeyStoreProviders(new Dictionary<string, SqlColumnEncryptionKeyStoreProvider>(1, StringComparer.OrdinalIgnoreCase)
                {
                    {
                        SqlColumnEncryptionAzureKeyVaultProvider.ProviderName, new SqlColumnEncryptionAzureKeyVaultProvider(new ClientSecretCredential(
                            Environment.GetEnvironmentVariable("tenantId"),
                            Environment.GetEnvironmentVariable("clientId"), 
                            Environment.GetEnvironmentVariable("clientSecret")
                            )
                        )
                    }
                });
            }
            else
            {
                SqlConnection.RegisterColumnEncryptionKeyStoreProviders(new Dictionary<string, SqlColumnEncryptionKeyStoreProvider>(1, StringComparer.OrdinalIgnoreCase)
                {
                    {
                        SqlColumnEncryptionAzureKeyVaultProvider.ProviderName, new SqlColumnEncryptionAzureKeyVaultProvider(new ManagedIdentityCredential())
                    }
                });
            }
            #endregion
            return services;
        }
    }
}
