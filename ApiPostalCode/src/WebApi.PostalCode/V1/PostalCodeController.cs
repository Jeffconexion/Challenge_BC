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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("/json/postalCode")]
    [HttpGet]
    public async Task<ActionResult<string>> GetJsonPostalCode([FromQuery] PostalCodeViewModel postalCodeViewModel)
    {
      string postalCodeResult = await _iOutsourcingPostalCodeServices.SearchPostalCodeJson(postalCodeViewModel.PostalCode);
      return postalCodeResult;
    }

    /// <summary>
    /// Method to find for the postal code
    /// </summary>
    /// <param name="postalCodeViewModel">postal code.</param>
    /// <returns>return object PostalCodeDtos</returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("/object/postalCode")]
    [HttpGet]
    public async Task<ActionResult<PostalCodeDtos>> SearchPostalCodeObject([FromQuery] PostalCodeViewModel postalCodeViewModel)
    {
      PostalCodeDtos postalCodeResult = await _iOutsourcingPostalCodeServices.SearchPostalCodeObject(postalCodeViewModel.PostalCode);
      return postalCodeResult;
    }
  }
}
