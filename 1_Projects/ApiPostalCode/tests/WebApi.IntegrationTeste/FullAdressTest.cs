using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using WebApi.Core.Dtos;
using WebApi.IntegrationTeste.Config;
using WebApi.PostalCode;
using Xunit;

namespace WebApi.IntegrationTeste
{
  [Collection(nameof(IntegrationApiTestsFixtureCollection))]
  public class FullAdressTest
  {
    private readonly IntegrationTestsFixture<Startup> _testsFixture;

    public FullAdressTest(IntegrationTestsFixture<Startup> testsFixture)
    {
      _testsFixture = testsFixture;
    }

    [Fact(DisplayName = "Search Postal Code With Successfully")]
    [Trait("Postal Code", "Outsourcing Postal Code Tests")]
    public async Task PostalCode_Find_CanBeTrue()
    {
      //act
      var getPostalCodeResponse = await _testsFixture.Client.GetAsync($"api/v1/postalCode/" + "01035-000");

      var jsonResponse = getPostalCodeResponse.Content.ReadAsStringAsync().Result;
      var postalCode = JsonSerializer.Deserialize<PostalCodeDtos>(jsonResponse);

      //assert
      postalCode.Ok.Should().BeTrue().And.Be(true);
      postalCode.Should().NotBeNull();
    }

    [Fact(DisplayName = "Search Postal Code Not Successfully")]
    [Trait("Postal Code", "Outsourcing Postal Code Tests")]
    public async Task PostalCode_Find_CanBeFalse()
    {
      //act
      var getPostalCodeResponse = await _testsFixture.Client.GetAsync($"api/v1/postalCode/" + "00000-000");

      var jsonResponse = getPostalCodeResponse.Content.ReadAsStringAsync().Result;
      var postalCode = JsonSerializer.Deserialize<PostalCodeDtos>(jsonResponse);

      //assert
      postalCode.Ok.Should().BeFalse().And.Be(false);
    }
  }
}
