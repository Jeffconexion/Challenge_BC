using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using WebApi.Application.CustomerServices;
using WebApi.Core.Entities.Views;
using WebApi.Core.IRepository;
using WebApi.Infrastructure.ExternalServices.IExternalServices;
using Xunit;

namespace WebApi.UnitTest.CustomerTests
{
  public class GetCustomerTests
  {
    [Fact(DisplayName = "Get Customers.")]
    [Trait("Get Customers", "Return List")]
    public void Customer_GetCustomers_ReturnList()
    {
      //Arrange
      var vwFullDataCustomer = new List<VwFullDataCustomer>
      {
        new VwFullDataCustomer()
        {
           Name = "Anderson Jorge Aragão",
           TaxId = "604.316.847-23",
           PhoneNumber = "(48) 2744-4584",
           CreatedAt = DateTime.Now,
           Code = "88058-257",
           Street = "Servidão Arrastão",
           District = "Ingleses do Rio Vermelho",
           City = "Florianópolis",
           State = "SC",
           Status = "Approved"
        },

        new VwFullDataCustomer()
        {
           Name = "Melissa Vanessa Melo",
           TaxId = "735.778.915-21",
           PhoneNumber = "(98) 2642-3258",
           CreatedAt = DateTime.Now,
           Code = "65066-664",
           Street = "Rua Bacurituba",
           District = "Turu",
           City = "São Luís",
           State = "MA",
           Status = "Approved"
        }
      };

      var repositoryCustomerMock = new Mock<IRepositoryCustomer>();
      var postalCodeServicesMock = new Mock<IPostalCodeServices>();

      //Set behaivor my repository
      repositoryCustomerMock.Setup(c => c.GetFullDataWithFilter("", "", "").Result).Returns(vwFullDataCustomer);

      var customerService = new CustomerService(repositoryCustomerMock.Object, postalCodeServicesMock.Object);

      //Act
      IEnumerable<VwFullDataCustomer> vwFullDataCustomerList = customerService.GetFullDataWithFilter("", "", "").Result;

      //Assert
      vwFullDataCustomerList.Should().NotBeNull().And.NotBeEmpty();
    }

    [Fact(DisplayName = "Get Customers.")]
    [Trait("Get Customers", "Return Empty")]
    public void Customer_GetCustomers_ReturnEmpty()
    {
      //Arrange
      var vwFullDataCustomer = new List<VwFullDataCustomer>
      {

      };

      var repositoryCustomerMock = new Mock<IRepositoryCustomer>();
      var postalCodeServicesMock = new Mock<IPostalCodeServices>();

      //Set behaivor my repository
      repositoryCustomerMock.Setup(c => c.GetFullDataWithFilter("", "", "").Result).Returns(vwFullDataCustomer);

      var customerService = new CustomerService(repositoryCustomerMock.Object, postalCodeServicesMock.Object);

      //Act
      IEnumerable<VwFullDataCustomer> vwFullDataCustomerList = customerService.GetFullDataWithFilter("", "", "").Result;

      //Assert
      vwFullDataCustomerList.Should().BeNullOrEmpty();
    }

    [Fact(DisplayName = "Times once call.")]
    [Trait("Verify Method", "Return true")]
    public void Customer_VerifyTimesOnce_ReturnTrue()
    {
      //Arrange
      var vwFullDataCustomer = new List<VwFullDataCustomer>
      {
        new VwFullDataCustomer()
        {
           Name = "Anderson Jorge Aragão",
           TaxId = "604.316.847-23",
           PhoneNumber = "(48) 2744-4584",
           CreatedAt = DateTime.Now,
           Code = "88058-257",
           Street = "Servidão Arrastão",
           District = "Ingleses do Rio Vermelho",
           City = "Florianópolis",
           State = "SC",
           Status = "Approved"
        },

        new VwFullDataCustomer()
        {
           Name = "Melissa Vanessa Melo",
           TaxId = "735.778.915-21",
           PhoneNumber = "(98) 2642-3258",
           CreatedAt = DateTime.Now,
           Code = "65066-664",
           Street = "Rua Bacurituba",
           District = "Turu",
           City = "São Luís",
           State = "MA",
           Status = "Approved"
        }
      };

      var repositoryCustomerMock = new Mock<IRepositoryCustomer>();
      var postalCodeServicesMock = new Mock<IPostalCodeServices>();

      //Set behaivor my repository
      repositoryCustomerMock.Setup(c => c.GetFullDataWithFilter("", "", "").Result).Returns(vwFullDataCustomer);

      var customerService = new CustomerService(repositoryCustomerMock.Object, postalCodeServicesMock.Object);

      //Act
      IEnumerable<VwFullDataCustomer> vwFullDataCustomerList = customerService.GetFullDataWithFilter("", "", "").Result;

      //Assert
      repositoryCustomerMock.Verify(cp => cp.GetFullDataWithFilter("", "", "").Result, Times.Once);

    }

  }
}
