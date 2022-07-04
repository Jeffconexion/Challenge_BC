using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ICustomerServices;
using WebApi.Core.Entities;
using WebApi.Infrastructure.ExternalServices.DtosExternal;
using WebApi.Infrastructure.ExternalServices.IExternalServices;
using WebApi.RegisterCustomer.Controllers;
using WebApi.RegisterCustomer.ViewModel;

namespace WebApi.RegisterCustomer.V1
{
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/Customer")]
  public class CustomerController : MainController
  {
    private readonly ICustomerService _customerService;
    private readonly IPostalCodeServices _postalCodeServices;

    public CustomerController(ICustomerService customerService, IPostalCodeServices postalCodeServices)
    {
      _customerService = customerService;
      _postalCodeServices = postalCodeServices;
    }

    [HttpPost("/account")]
    public async Task<ActionResult> RegisterCustomer([FromBody] CustomerViewModel customerViewModel)
    {

      PostalCodeDtos fullAddress = await _postalCodeServices.GetFullAddress(customerViewModel.PostalCode);

      //Customer customer = CustomerViewModel.ToEntity(customerViewModel);
      //await _customerService.CreateCustumer(customer);
      return null;
    }

    [HttpGet("/account")]
    public async Task<ActionResult> GetCustomer([FromQuery] FilterViewModel parameters)
    {
      var resultSearch = await _customerService.GetFullDataWithFilter(parameters.Name, parameters.TaxId, parameters.CreatedAt);
      return Ok(resultSearch);
    }

  }
}
