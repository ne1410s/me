﻿// <copyright file="MiddlewareFeaturesTests.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace AboutMe.Api.tests.FrameworkIntegration;

/// <summary>
/// Tests for miscellaneous http middleware.
/// </summary>
public class MiddlewareFeaturesTests
{
    private readonly HttpClient client;

    public MiddlewareFeaturesTests()
    {
        var appFactory = new TestingWebAppFactory();
        this.client = appFactory.CreateClient();
    }

    [Fact]
    public async Task UnsecureHttp_WhenRequested_HandledAsExpected()
    {
        // Arrange
        const string serviceUrl = "http://localhost:80/forecasts";

        // Act
        var response = await this.client.GetAsync(serviceUrl);

        // Assert
        response.RequestMessage!.RequestUri!.Scheme.Should().Be("https");
    }
}