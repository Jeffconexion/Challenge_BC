using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Dtos;
using WebApi.Application.IServices;
using WebApi.PostalCode.Controllers;
using WebApi.PostalCode.ViewModel;

namespace WebApi.PostalCode.V1
{
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/PostalCode")]
  public class PostalCodeController : MainController
  {
    private readonly IOutsourcingPostalCodeServices _iOutsourcingPostalCodeServices;

    public PostalCodeController(IOutsourcingPostalCodeServices iOutsourcingPostalCodeServices)
    {
      _iOutsourcingPostalCodeServices = iOutsourcingPostalCodeServices;
    }

    /// <summary>
    /// Method to find for the postal code
    /// </summary>
    /// <param name="postalCodeViewModel">postal code.</param>
    /// <returns>return string json</returns>
    /// <response code="200">The request was successful.</response>
    /// <response code="400">The server will not process the request due to an error in the information sent.</response>
    /// <response code="500">The server cannot process the request due to a maintenance condition or temporary overload.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("/json/postalCode")]
    [HttpGet]
    public async Task<ActionResult<string>> GetJsonPostalCode([FromQuery] PostalCodeViewModel postalCodeViewModel)
    {
      PostalCodeDtos postalCodeResult = await _iOutsourcingPostalCodeServices.SearchPostalCode(postalCodeViewModel.PostalCode);

      if (postalCodeResult.Ok is false)
      {
        return new JsonResult(postalCodeResult) { StatusCode = 400, Value = "The server will not process the request due to an error in the information sent" };
      }
      return new JsonResult(postalCodeResult) { StatusCode = 200 };
    }
  }
}
