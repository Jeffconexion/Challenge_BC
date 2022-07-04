using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ICustomerServices;
using WebApi.Core.Entities;
using WebApi.RegisterCustomer.Controllers;
using WebApi.RegisterCustomer.ViewModel;

namespace WebApi.RegisterCustomer.V1
{
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/Customer")]
  public class CustomerController : MainController
  {

    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
      _customerService = customerService;
    }

    [HttpPost("/account")]
    public async Task<ActionResult> RegisterCustomer([FromBody] CustomerViewModel customerViewModel)
    {
      Customer customer = CustomerViewModel.ToEntity(customerViewModel);
      await _customerService.CreateCustumer(customer);
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
