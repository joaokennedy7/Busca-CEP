using CEPDomain;
using CEPDomain.Contracts.AddressContracts;
using AddressDomain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace AddressDomain.Services
{
    public class DadosCEPDomainService
    {
        private readonly CorreiosServices _correioservices;

        public DadosCEPDomainService(CorreiosServices correiosServices)
        {
            _correioservices = correiosServices;
        }

        public Task<Address> NewAddressAsync(string cep, CancellationToken cancellationToken = default)
        {
            CreateAddress createaddress = new(cep);

            return _correioservices.GetAsync<Address>(createaddress, cancellationToken);
        }

    }
}