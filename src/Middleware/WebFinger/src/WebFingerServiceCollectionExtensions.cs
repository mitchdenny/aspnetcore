// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.WebFinger;

/// <summary>
/// Extension methods for the RateLimiting middleware.
/// </summary>
public static class WebFingerServiceCollectionExtensions
{
    public static IWebFingerBuilder AddWebFinger(this IServiceCollection services)
        => services.AddWebFinger((options) => { });

    /// <summary>
    /// Add Web Finger services and configure the related options.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> for adding services.</param>
    /// <param name="configureOptions">A delegate to configure the <see cref="WebFingerOptions"/>.</param>
    /// <returns></returns>
    public static IWebFingerBuilder AddWebFinger(this IServiceCollection services, Action<WebFingerOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);

        services.Configure(configureOptions);
        services.AddScoped<WebFingerHandler>();
        return new WebFingerBuilder(services);
    }
}
