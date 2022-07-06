using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ICustomerServices;
using WebApi.RegisterCustomer.ViewModel;

namespace WebApi.RegisterCustomer.Controllers.V1
{
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}")]
  public class CustomerController : MainController
  {
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
      _customerService = customerService;
    }

    /// <summary>
    /// Method to register a new customer.
    /// </summary>
    /// <param name="customerDtos">New Client.</param>
    /// <returns>return string json</returns>
    /// <response code="200">The request was successful.</response>
    /// <response code="201">The request was completely processed by the server and one or more resources were created as a result.</response>
    /// <response code="400">The server will not process the request due to an error in the information sent.</response>
    /// <response code="500">The server cannot process the request due to a maintenance condition or temporary overload.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("/account")]
    public async Task<IActionResult> RegisterCustomer([FromBody] CustomerDtos customerDtos)
    {
      try
      {
        var customer = CustomerDtos.ToEntity(customerDtos);
        var response = await _customerService.AddCustomer(customer, customerDtos.PostalCode);
        return CreatedAtAction("RegisterCustomer", customerDtos, response);
      }
      catch (HttpRequestException)
      {
        return BadRequest($"ApiPostalCode cannot process the request due to a maintenance condition or temporary overload. Status= {StatusCodes.Status400BadRequest}");
      }
    }


    /// <summary>
    /// Method to search for one or more customers.
    /// </summary>
    /// <param name="parameters">Parametrs to filter.</param>
    /// <returns>return string json</returns>
    /// <response code="200">The request was successful.</response>
    /// <response code="201">The request was completely processed by the server and one or more resources were created as a result.</response>
    /// <response code="400">The server will not process the request due to an error in the information sent.</response>
    /// <response code="500">The server cannot process the request due to a maintenance condition or temporary overload.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("/account")]
    public async Task<IActionResult> GetCustomer([FromQuery] FilterDtos parameters)
    {
      var resultSearch = await _customerService.GetFullDataWithFilter(parameters.Name, parameters.TaxId, parameters.CreatedAt);
      return CreatedAtAction("GetCustomer", parameters, resultSearch);
    }
  }
}
