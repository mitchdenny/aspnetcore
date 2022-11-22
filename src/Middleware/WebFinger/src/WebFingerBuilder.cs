// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.WebFinger;
public class WebFingerBuilder : IWebFingerBuilder
{
    private IServiceCollection _services;

    public WebFingerBuilder(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        _services = services;
    }

    public IWebFingerBuilder AddResolver<T>() where T: class, IWebFingerResolver
    {
        _services.AddScoped<IWebFingerResolver, T>();
        return this;
    }
}
