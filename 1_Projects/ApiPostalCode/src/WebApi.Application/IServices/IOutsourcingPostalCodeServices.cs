using System.Threading.Tasks;
using WebApi.Core.Dtos;

namespace WebApi.Application.IServices
{
  public interface IOutsourcingPostalCodeServices
  {
    Task<PostalCodeDtos> SearchPostalCode(string postalcode);
  }
}
