﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SalesApi.IoC.ModuleInitializers;

public class WebApiModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {

        builder.Services.AddControllers();
        builder.Services.AddHealthChecks();
    }
}