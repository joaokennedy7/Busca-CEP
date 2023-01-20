using AddressDomain.Entities;
using System.Threading.Tasks;

namespace AddressInfra.Repository
{
    public interface IAddressRepository
    {
        Task PostAsync(Address address);
        Task<Address> GetAddressAsync(string cep);
    }
}
