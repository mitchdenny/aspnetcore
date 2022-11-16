// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.WebFinger;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddWebFinger((options) => { });

var app = builder.Build();
app.UseWebFinger();

app.MapGet("/", () => "Hello World!");

app.Run();
