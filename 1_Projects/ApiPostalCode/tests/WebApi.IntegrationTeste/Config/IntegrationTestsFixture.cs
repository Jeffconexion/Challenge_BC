﻿using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using WebApi.PostalCode;
using Xunit;

namespace WebApi.IntegrationTeste.Config
{
  [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
  public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<Startup>> { }

  public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
  {
    public readonly ApiFactory<TStartup> Factory;
    public HttpClient Client;

    public IntegrationTestsFixture()
    {
      var clientOptions = new WebApplicationFactoryClientOptions
      {
        AllowAutoRedirect = true,
        BaseAddress = new Uri("https://localhost:44338/"),
        HandleCookies = true,
        MaxAutomaticRedirections = 7
      };

      Factory = new ApiFactory<TStartup>();
      Client = Factory.CreateClient(clientOptions);
    }

    public void Dispose()
    {
      Client.Dispose();
      Factory.Dispose();
    }
  }
}
