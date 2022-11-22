// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BasicWebFingerSample;
using Microsoft.AspNetCore.WebFinger;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddWebFinger().AddResolver<DummyResolver>();

var app = builder.Build();
app.MapWebFinger();

app.MapGet("/", () => "Hello World!");

app.Run();
