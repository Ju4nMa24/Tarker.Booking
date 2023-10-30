using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tarker.Booking.Application.External.ApplicationInsights;
using Tarker.Booking.Application.External.Jwt;
using Tarker.Booking.Application.External.SendGridEmail;
using Tarker.Booking.External.ApplicationInsights;
using Tarker.Booking.External.Jwt;
using Tarker.Booking.External.SendGrid;

namespace Tarker.Booking.External.DIConfigurations
{
    /// <summary>
    /// DI.
    /// </summary>
    public static class DependencyInjectionService
    {
        /// <summary>
        /// Register DI.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration configuration)
        {
            #region Twilio API Repositories
            services.AddSingleton<ISendGridEmailService, SendGridEmailService>();
            #endregion

            #region JWT Repositories
            services.AddSingleton<IGetTokenJwtService, GetTokenJwtService>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKeyJwt"] ?? string.Empty)),
                    ValidIssuer = configuration["IssuerJwt"],
                    ValidAudience = configuration["AudienceJwt"]
                };
            });
            #endregion

            #region Application Insights Repositories
            services.AddSingleton<IInsertApplicationInsightsService, InsertApplicationInsightsService>();
            services.AddApplicationInsightsTelemetry(new ApplicationInsightsServiceOptions
            {
                ConnectionString = configuration["ApplicationInsightsConnectionString"]
            });
            #endregion
            return services;
        }
    }
}
