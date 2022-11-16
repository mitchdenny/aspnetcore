// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Builder;

namespace Microsoft.AspNetCore.WebFinger;

public static class WebFingerApplicationBuilderExtensions
{
    /// <summary>
    /// Add WebFinger middleware.
    /// </summary>
    /// <param name="app">App builder.</param>
    /// <returns></returns>
    public static IApplicationBuilder UseWebFinger(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.UseMiddleware<WebFingerMiddleware>();

        return app;
    }
}
