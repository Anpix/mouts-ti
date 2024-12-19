using MediatR;
using System;

namespace SalesApi.WebApi.Config;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        #region General
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        #endregion

        #region Domains
        #endregion

        return services;
    }
}
