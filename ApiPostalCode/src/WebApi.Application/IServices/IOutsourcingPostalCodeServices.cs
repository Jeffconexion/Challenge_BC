using System.Threading.Tasks;
using WebApi.Application.Dtos;

namespace WebApi.Application.IServices
{
  public interface IOutsourcingPostalCodeServices
  {
    Task<string> SearchPostalCodeJson(string postalcode);
    Task<PostalCodeDtos> SearchPostalCodeObject(string postalcode);

  }
}
