﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable

using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Moq;
using Xunit;

namespace Microsoft.AspNetCore.Razor.Language;

public class RazorProjectEngineBuilderExtensionsTest
{
    [Fact]
    public void SetImportFeature_SetsTheImportFeature()
    {
        // Arrange
        var builder = new RazorProjectEngineBuilder(RazorConfiguration.Default, Mock.Of<RazorProjectFileSystem>());
        var testFeature1 = new TestImportProjectFeature();
        var testFeature2 = new TestImportProjectFeature();
        builder.Features.Add(testFeature1);
        builder.Features.Add(testFeature2);
        var newFeature = new TestImportProjectFeature();

        // Act
        builder.SetImportFeature(newFeature);

        // Assert
        var feature = Assert.Single(builder.Features);
        Assert.Same(newFeature, feature);
    }

    [Fact]
    public void AddTargetExtension_CreatesAndAddsToTargetExtensionFeatureIfItDoesNotExist()
    {
        // Arrange
        var builder = new RazorProjectEngineBuilder(RazorConfiguration.Default, Mock.Of<RazorProjectFileSystem>());
        var expectedExtension = Mock.Of<ICodeTargetExtension>();

        // Act
        builder.AddTargetExtension(expectedExtension);

        // Assert
        var feature = Assert.Single(builder.Features);
        var codeTargetExtensionFeature = Assert.IsAssignableFrom<IRazorTargetExtensionFeature>(feature);
        var extensions = Assert.Single(codeTargetExtensionFeature.TargetExtensions);
        Assert.Same(expectedExtension, extensions);
    }

    [Fact]
    public void AddTargetExtension_UsesExistingFeatureIfExistsAndAddsTo()
    {
        // Arrange
        var builder = new RazorProjectEngineBuilder(RazorConfiguration.Default, Mock.Of<RazorProjectFileSystem>());
        var codeTargetExtensionFeature = new DefaultRazorTargetExtensionFeature();
        builder.Features.Add(codeTargetExtensionFeature);
        var expectedExtension = Mock.Of<ICodeTargetExtension>();

        // Act
        builder.AddTargetExtension(expectedExtension);

        // Assert
        var feature = Assert.Single(builder.Features);
        Assert.Same(codeTargetExtensionFeature, feature);
        var extensions = Assert.Single(codeTargetExtensionFeature.TargetExtensions);
        Assert.Same(expectedExtension, extensions);
    }

    [Fact]
    public void AddDirective_CreatesAndAddsToDirectiveFeatureIfItDoesNotExist()
    {
        // Arrange
        var builder = new RazorProjectEngineBuilder(RazorConfiguration.Default, Mock.Of<RazorProjectFileSystem>());
        var expectedDirective = Mock.Of<DirectiveDescriptor>();

        // Act
        builder.AddDirective(expectedDirective);

        // Assert
        var feature = Assert.Single(builder.Features);
        var directiveFeature = Assert.IsAssignableFrom<IRazorDirectiveFeature>(feature);
        var directive = Assert.Single(directiveFeature.Directives);
        Assert.Same(expectedDirective, directive);
    }

    [Fact]
    public void AddDirective_UsesExistingFeatureIfExistsAndAddsTo()
    {
        // Arrange
        var builder = new RazorProjectEngineBuilder(RazorConfiguration.Default, Mock.Of<RazorProjectFileSystem>());
        var directiveFeature = new DefaultRazorDirectiveFeature();
        builder.Features.Add(directiveFeature);
        var expecteDirective = Mock.Of<DirectiveDescriptor>();

        // Act
        builder.AddDirective(expecteDirective);

        // Assert
        var feature = Assert.Single(builder.Features);
        Assert.Same(directiveFeature, feature);
        var directive = Assert.Single(directiveFeature.Directives);
        Assert.Same(expecteDirective, directive);
    }
}
