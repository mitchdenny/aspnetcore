// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.AspNetCore.WebFinger;

public static class WebFingerEndpointRouteBuilderExtensions
{
    /// <summary>
    /// Add WebFinger middleware.
    /// </summary>
    /// <param name="app">App builder.</param>
    /// <returns></returns>
    public static IEndpointConventionBuilder MapWebFinger(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        return endpoints.MapGet(
            "/.well-known/webfinger",
            async (HttpContext context, [FromQuery]string resource, [FromQuery(Name = "rel")]string relation, [FromServices]WebFingerHandler handler) =>
            {
                await handler.HandleAsync(context, resource, relation);
            });
    }
}
