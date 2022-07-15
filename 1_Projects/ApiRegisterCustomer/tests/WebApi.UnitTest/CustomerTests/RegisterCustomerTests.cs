using FluentAssertions;
using Moq;
using WebApi.Application.CustomerServices;
using WebApi.Application.Dtos;
using WebApi.Core.IRepository;
using WebApi.Infrastructure.ExternalServices.IExternalServices;
using WebApi.RegisterCustomer.ViewModel;
using Xunit;

namespace WebApi.UnitTest.RegisterCustomer
{
  public class RegisterCustomerTests
  {
    [Fact(DisplayName = "Register Customer.")]
    [Trait("New Customer", "Return true")]
    public void Customer_CreateNew_ReturnTrue()
    {
      // Arrange
      CustomerDtos customerDtos = new CustomerDtos()
      {
        Name = "Teste",
        Password = "12345Rt%$@",
        TaxId = "557.611.520-10",
        PhoneNumber = "(11) 987223476",
        PostalCode = "01035-000"
      };
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
