using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Options;
using WebApi.Application.Config;
using WebApi.Application.Dtos;
using WebApi.Application.Services;
using Xunit;

namespace WebApi.UnitTest.Services
{
  public class OutsourcingPostalCodeServicesTests
  {
    private IOptions<ZipsSettings> _options;

    private string PostalCodeValid { get; set; }
    private string PostalCodeInvalid { get; set; }
    private string PostalCodeEmpty { get; set; }

    public OutsourcingPostalCodeServicesTests()
    {
      PostalCodeValid = "01035-000";
      PostalCodeInvalid = "##$%¨&*";
    }

    [Fact(DisplayName = "Search Postal Code With Successfully")]
    [Trait("Postal Code", "Outsourcing Postal Code Service Mock Tests")]
    public async Task OutsourcingPostalCodeServices_search_shouldRunSuccessfully()
    {
      //Arrange
      ZipsSettings teste = new ZipsSettings() { Widenet = "https://apps.widenet.com.br/busca-cep/api/cep.json?code=" };
      _options = Options.Create(teste);

      var outsourcingPostalCodeServices = new OutsourcingPostalCodeServices(_options);

      //Act
      PostalCodeDtos postalCodeResult = await outsourcingPostalCodeServices.SearchPostalCode(PostalCodeValid);

      //Assert
      postalCodeResult.Ok.Should().BeTrue().And.NotBe(false);
    }

    [Fact(DisplayName = "Search Postal Code With not Successfully")]
    [Trait("Postal Code", "Outsourcing Postal Code Service Mock Tests")]
    public async Task OutsourcingPostalCodeServices_search_shouldNotRunSuccessfully()
    {
      //Arrange
      ZipsSettings teste = new ZipsSettings() { Widenet = "https://apps.widenet.com.br/busca-cep/api/cep.json?code=" };
      _options = Options.Create(teste);

      var outsourcingPostalCodeServices = new OutsourcingPostalCodeServices(_options);

      //Act
      PostalCodeDtos postalCodeResult = await outsourcingPostalCodeServices.SearchPostalCode(PostalCodeInvalid);

      //Assert
      postalCodeResult.Ok.Should().BeFalse().And.NotBe(true);
    }

    [Fact(DisplayName = "Search Postal Code With Empty Successfully")]
    [Trait("Postal Code", "Outsourcing Postal Code Service Mock Tests")]
    public async Task OutsourcingPostalCodeServices_search_shouldNotRunWithEmptySuccessfully()
    {
      //Arrange
      ZipsSettings teste = new ZipsSettings() { Widenet = "https://apps.widenet.com.br/busca-cep/api/cep.json?code=" };
      _options = Options.Create(teste);

      var outsourcingPostalCodeServices = new OutsourcingPostalCodeServices(_options);

      //Act
      PostalCodeDtos postalCodeResult = await outsourcingPostalCodeServices.SearchPostalCode(PostalCodeEmpty);

      //Assert
      postalCodeResult.Ok.Should().BeFalse().And.NotBe(true);
    }

    [Fact(DisplayName = "Search Postal Code With Successfully")]
    [Trait("Postal Code", "Outsourcing Postal Code Service Mock Tests")]
    public async Task OutsourcingPostalCodeServices_search_shouldRunSuccessfullyManyParameters()
    {
      //Arrange
      ZipsSettings teste = new ZipsSettings() { Widenet = "https://apps.widenet.com.br/busca-cep/api/cep.json?code=" };
      _options = Options.Create(teste);

      var outsourcingPostalCodeServices = new OutsourcingPostalCodeServices(_options);

      //Act
      PostalCodeDtos postalCodeResult = await outsourcingPostalCodeServices.SearchPostalCode(PostalCodeValid);

      //Assert
      postalCodeResult.Status.Should().Be(200);
      postalCodeResult.Ok.Should().BeTrue().And.NotBe(false);
      postalCodeResult.State.Should().NotBeNullOrEmpty().And.BeEquivalentTo(postalCodeResult.State);
      postalCodeResult.City.Should().NotBeNullOrEmpty().And.BeEquivalentTo(postalCodeResult.City);
      postalCodeResult.Address.Should().BeOneOf(postalCodeResult.Address, "");
      postalCodeResult.District.Should().BeOneOf(postalCodeResult.District, "");
      postalCodeResult.Code.Should().NotBeNullOrEmpty().And.BeEquivalentTo(postalCodeResult.Code);
    }
  }
}
