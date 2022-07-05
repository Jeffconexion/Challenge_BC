﻿using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Infrastructure.ExternalServices.DtosExternal;
using WebApi.Infrastructure.ExternalServices.IExternalServices;

namespace WebApi.Infrastructure.ExternalServices
{
  public class PostalCodeServices : IPostalCodeServices
  {
    private readonly IExternalHttpManagerServices _externalHttpManagerServices;

    public PostalCodeServices(IExternalHttpManagerServices externalHttpManagerServices)
    {
      _externalHttpManagerServices = externalHttpManagerServices;
    }

    public async Task<PostalCodeDtos> GetFullAddress(string postalCodeDtos)
    {
      var endpointQuery = $" api/v1/postalCode/{postalCodeDtos}";

      PostalCodeDtos response = await _externalHttpManagerServices.CallGetApiPostalCode<PostalCodeDtos, FormUrlEncodedContent>(null, endpointQuery, HttpMethod.Get);

      return response;
    }
  }
}
