using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Infrastructure.ExternalServices;
using WebApi.Infrastructure.ExternalServices.DtosExternal;
using WebApi.Infrastructure.ExternalServices.IExternalServices;
using Xunit;

namespace WebApi.UnitTest.ExternalServicesTests
{
  public class PostalCodeServicesTests
  {
    private static readonly IExternalHttpManagerServices _externalHttpManagerServices;

    static PostalCodeServicesTests()
    {
      _externalHttpManagerServices = new ExternalHttpManagerServices();
    }

    /// <summary>
    /// You need to run ApiPostalCode so that you can test this method.
    /// </summary>
    /// <returns></returns>
    [Theory(DisplayName = "Check Endpoint.")]
    [Trait("External HttpService", "Can be not null or HttpRequestException")]
    [InlineData("19085-220")]
    [InlineData("69317-394")]
    [InlineData("21842-602")]
    [InlineData("79106-064")]
    public async Task ExternalHttpService_CheckEndpoint_NotBeNull(string postalCodeDtos)
    {
      //Arrange
      PostalCodeDtos ApiPostalCodeResponse = new PostalCodeDtos();
      var endpointQuery = $" api/v1/postalCode/{postalCodeDtos}";

      try
      {
        //Act
        ApiPostalCodeResponse = await _externalHttpManagerServices.CallGetApiPostalCode<PostalCodeDtos, FormUrlEncodedContent>(requestBody: null, endpoint: endpointQuery, verb: HttpMethod.Get);


        //Assert
        ApiPostalCodeResponse.Should().NotBeNull().And.BeOfType<PostalCodeDtos>("because a {0} is set", typeof(PostalCodeDtos)).Which.State.Should().NotBeNullOrEmpty();

      }
      catch (HttpRequestException ex)
      {
        ex.Should().BeOfType<HttpRequestException>()
                   .Which.Message.Should().Be("Nenhuma conexão pôde ser feita porque a máquina de destino as recusou ativamente. (localhost:44338)");

      }
    }
  }
}
