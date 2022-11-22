// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.WebFinger;
public class WebFingerResolutionContext
{
    public WebFingerResolutionContext(HttpContext httpContext, string resource, string relation)
    {
        ArgumentNullException.ThrowIfNull(httpContext);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(relation);

        HttpContext = httpContext;
        Resource = resource;
        Relation = relation;
    }

    public HttpContext HttpContext { get; private set; }
    public string Resource { get; private set; }
    public string Relation { get; private set; }

    private List<string> _aliases = new List<string>();
    private List<Tuple<string, string, string>> _links = new List<Tuple<string, string, string>>();

    public void AddProperty(string name, object value)
    {
    }

    public void AddAlias(string alias)
    {
        _aliases.Add(alias);
    }

    public void AddLink(string relation, string type, string href)
    {
        _links.Add(relation, type, href);
    }
}
