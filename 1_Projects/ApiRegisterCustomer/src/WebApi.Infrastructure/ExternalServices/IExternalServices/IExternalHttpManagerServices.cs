﻿using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.Infrastructure.ExternalServices.IExternalServices
{
  public interface IExternalHttpManagerServices
  {
    Task<TOutput> CallGetApiPostalCode<TOutput, TInput>(TInput requestBody, string endpoint, HttpMethod verb) where TInput : HttpContent;
  }
}
