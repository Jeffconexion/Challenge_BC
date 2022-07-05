using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.IServices;
using WebApi.Core.Dtos;

namespace WebApi.PostalCode.Controllers.V1
{
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/postalCode")]
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
    /// <param name="postalCodeDtos">postal code.</param>
    /// <returns>return string json</returns>
    /// <response code="200">The request was successful.</response>
    /// <response code="201">The request was completely processed by the server and one or more resources were created as a result.</response>
    /// <response code="400">The server will not process the request due to an error in the information sent.</response>
    /// <response code="500">The server cannot process the request due to a maintenance condition or temporary overload.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("{postalCodeDtos}")]
    public async Task<ActionResult> GetJsonPostalCode(string postalCodeDtos)
    {
      PostalCodeDtos postalCodeResult = await _iOutsourcingPostalCodeServices.SearchPostalCode(postalCodeDtos);

      if (postalCodeResult.Ok is false)
      {
        return BadRequest(new { Status = postalCodeResult.Status, StatusText = "The server will not process the request due to an error in the information sent, please enter a valid zip code." });

      }

      return CreatedAtAction("GetJsonPostalCode", postalCodeDtos, postalCodeResult);
    }
  }
}
