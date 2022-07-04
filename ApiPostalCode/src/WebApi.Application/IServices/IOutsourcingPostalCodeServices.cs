using System.Threading.Tasks;
using WebApi.Application.Dtos;

namespace WebApi.Application.IServices
{
  public interface IOutsourcingPostalCodeServices
  {
    Task<PostalCodeDtos> SearchPostalCode(string postalcode);
  }
}
