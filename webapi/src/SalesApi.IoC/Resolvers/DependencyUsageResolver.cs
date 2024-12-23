﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using SalesApi.Common.Extensions;
using SalesApi.Common.Middlewares;

namespace SalesApi.IoC.Resolvers;

public static class DependencyUsageResolver
{
    public static WebApplication UseDependencies(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseBasicHealthChecks();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.MapControllers();

        return app;
    }
}
