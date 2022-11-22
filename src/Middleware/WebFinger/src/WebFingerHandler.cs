// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.WebFinger;
internal class WebFingerHandler
{
    private readonly ILogger<WebFingerHandler> _logger;
    private readonly IEnumerable<IWebFingerResolver> _resolvers;

    public WebFingerHandler(ILogger<WebFingerHandler> logger, IEnumerable<IWebFingerResolver> resolvers)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(resolvers);

        _logger = logger;
        _resolvers = resolvers;
    }

    internal async Task HandleAsync(HttpContext context, string resource, string relation)
    {
        var resolutionContext = new WebFingerResolutionContext(context, resource, relation);

        foreach (var resolver in _resolvers)
        {
            await resolver.ResolveAsync(resolutionContext);
        }

        
    }
}
