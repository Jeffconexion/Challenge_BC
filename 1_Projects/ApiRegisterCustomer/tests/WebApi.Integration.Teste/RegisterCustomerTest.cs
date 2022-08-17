using System.Net.Http.Json;
using System.Threading.Tasks;
using Moq;
using WebApi.Infrastructure.ExternalServices.IExternalServices;
using WebApi.Integration.Teste.Config;
using WebApi.RegisterCustomer;
using WebApi.RegisterCustomer.ViewModel;
using Xunit;

namespace WebApi.Integration.Teste
{
  [Collection(nameof(IntegrationApiTestsFixtureCollection))]
  public class RegisterCustomerTest
  {
    private readonly IntegrationTestsFixture<StartupApiTest> _testsFixture;

    public RegisterCustomerTest(IntegrationTestsFixture<StartupApiTest> testsFixture)
    {
      _testsFixture = testsFixture;
    }

    [Fact(DisplayName = "Register new Customer")]
    [Trait("New Customer E2E", "Register new customer and return result.")]
    public async Task Customer_RegisterCustomer_CanBeTrue()
    {
      //arrange
      Mock<IPostalCodeServices> _postalCodeService = new Mock<IPostalCodeServices>();
      CustomerDtos customer = new CustomerDtos()
      {
        Name = "Sebastiana",
        TaxId = "38814041806",
        Password = "12s34T56#",
        PhoneNumber = "(79) 2601-8122",
        PostalCode = "49095-780"
      };

      //act
      var resultResponse = await _testsFixture.Client.PostAsJsonAsync($"account", customer);

      //Assert
      resultResponse.EnsureSuccessStatusCode();
    }

  }
}


