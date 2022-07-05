using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Dtos;
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
    public async Task<IActionResult> RegisterCustomer([FromBody] CustomerViewModel customerViewModel)
    {
      try
      {
        PostalCodeDtos fullAddress = await _postalCodeServices.GetFullAddress(customerViewModel.PostalCode);

        Customer customer = CustomerViewModel.ToEntity(customerViewModel);
        ResponseDtos response = await _customerService.AddCustomer(customer, fullAddress);
        return CreatedAtAction("RegisterCustomer", customerViewModel, response);
      }
      catch (HttpRequestException)
      {
        return BadRequest($"ApiPostalCode cannot process the request due to a maintenance condition or temporary overload. Status= {StatusCodes.Status400BadRequest}");
      }
    }

    [HttpGet("/account")]
    public async Task<IActionResult> GetCustomer([FromQuery] FilterViewModel parameters)
    {
      var resultSearch = await _customerService.GetFullDataWithFilter(parameters.Name, parameters.TaxId, parameters.CreatedAt);
      return CreatedAtAction("GetCustomer", parameters, resultSearch);
    }

  }
}
