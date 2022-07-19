using FluentAssertions;
using Moq;
using WebApi.Application.CustomerServices;
using WebApi.Application.Dtos;
using WebApi.Core.IRepository;
using WebApi.Infrastructure.ExternalServices.IExternalServices;
using WebApi.RegisterCustomer.ViewModel;
using WebApi.UnitTest.CustomerTests;
using Xunit;

namespace WebApi.UnitTest.RegisterCustomer
{
  [Collection(nameof(CustomerBogusCollection))]
  public class RegisterCustomerTests
  {
    public readonly CustomerTesteBogus _customerTesteBogus;

    public RegisterCustomerTests(CustomerTesteBogus customerTesteBogus)
    {
      _customerTesteBogus = customerTesteBogus;
    }

    [Fact(DisplayName = "Register Customer.")]
    [Trait("New Customer", "Return true")]
    public void Customer_CreateNew_ReturnTrue()
    {
      // Arrange      
      var customerDtos = _customerTesteBogus.GenerateValidCustomer();
      var customer = CustomerDtos.ToEntity(customerDtos);
      var clienteRepo = new Mock<IRepositoryCustomer>();
      var postalCodeServices = new Mock<IPostalCodeServices>();
      var customerService = new CustomerService(clienteRepo.Object, postalCodeServices.Object);

      // Act
      var resultNewCustomer = customerService.AddCustomer(customer, customerDtos.PostalCode).Result;

      // Assert
      resultNewCustomer.Should().NotBeNull().And.NotBe(false).And.BeOfType(typeof(ResponseDtos));
    }
  }
}
