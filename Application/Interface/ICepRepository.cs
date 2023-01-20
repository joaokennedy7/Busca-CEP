using AddressDomain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace AddressApplication.Interface
{
   public interface ICEPRepository
   {
        Task<ObjectResponse> PostAddressAsync (string cep, CancellationToken cancellationToken = default);
        Task<Address> GetAddress(string cep, CancellationToken cancellationToken = default);
   }
}
