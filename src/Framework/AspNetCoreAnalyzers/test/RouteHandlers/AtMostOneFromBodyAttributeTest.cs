// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Security.Policy;
using Microsoft.CodeAnalysis.Testing;
using VerifyCS = Microsoft.AspNetCore.Analyzers.Verifiers.CSharpAnalyzerVerifier<Microsoft.AspNetCore.Analyzers.RouteHandlers.RouteHandlerAnalyzer>;

namespace Microsoft.AspNetCore.Analyzers.RouteHandlers;

public partial class AtMostOneFromBodyAttributeTest
{
    private TestDiagnosticAnalyzerRunner Runner { get; } = new(new RouteHandlerAnalyzer());

    [Fact]
    public async Task Handler_With_No_FromBody_Attributes_Works()
    {
        // Arrange
        var source = @"
using Microsoft.AspNetCore.Builder;
var webApp = WebApplication.Create();
webApp.MapPost(""/products/{productId}"", (string productId, Product product) => {});

public class Product
{
}
";

        // Act
        await VerifyCS.VerifyAnalyzerAsync(source);
    }

    [Fact]
    public async Task Handler_With_One_FromBody_Attributes_Works()
    {
        // Arrange
        var source = @"
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
var webApp = WebApplication.Create();
webApp.MapPost(""/products/{productId}"", (string productId, [FromBody]Product product) => {});

public class Product
{
}
";

        // Act
        await VerifyCS.VerifyAnalyzerAsync(source);
    }

    [Fact]
    public async Task Handler_With_Two_FromBody_Attributes_Fails()
    {
        // Arrange
        var source = @"
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
var webApp = WebApplication.Create();
webApp.MapPost(""/products/{productId}"", (string productId, {|#0:[FromBody]Product product1|}, {|#1:[FromBody]Product product2|}) => {});

public class Product
{
}
";

        var expectedDiagnostic1 = new DiagnosticResult(DiagnosticDescriptors.AtMostOneFromBodyAttribute).WithLocation(0);
        var expectedDiagnostic2 = new DiagnosticResult(DiagnosticDescriptors.AtMostOneFromBodyAttribute).WithLocation(1);

        // Act
        await VerifyCS.VerifyAnalyzerAsync(
            source,
            expectedDiagnostic1,
            expectedDiagnostic2
            );
    }
}
