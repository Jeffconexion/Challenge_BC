using System;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using WebApi.RegisterCustomer.ViewModel;
using Xunit;

namespace WebApi.UnitTest.CustomerTests
{
  [CollectionDefinition(nameof(CustomerBogusCollection))]
  public class CustomerBogusCollection : ICollectionFixture<CustomerTesteBogus>
  {
  }

  public class CustomerTesteBogus : IDisposable
  {

    public CustomerDtos GenerateValidCustomer()
    {
      return GenerateCustomer();
    }

    private CustomerDtos GenerateCustomer()
    {
      var genero = new Faker().PickRandom<Name.Gender>();

      var customer = new Faker<CustomerDtos>("pt_BR")
        .CustomInstantiator(f => new CustomerDtos(
          f.Name.FirstName(genero),
          f.Person.Cpf(),
          f.Internet.Password(),
          f.Phone.PhoneNumber(),
          f.Address.ZipCode()
             ));

      return customer;
    }

    public void Dispose()
    {
    }
  }

}
