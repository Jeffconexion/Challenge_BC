using System.Threading.Tasks;
using WebApi.Infrastructure.ExternalServices.DtosExternal;

namespace WebApi.Infrastructure.ExternalServices.IExternalServices
{
  public interface IPostalCodeServices
  {
    Task<PostalCodeDtos> GetFullAddress(string postalCode);
  }
}
