using AutoMapper;
using CEP.AddressApplication.Interface;
using AddressApplication.Interface;
using AddressDomain.Entities;
using AddressDomain.Services;
using AddressInfra.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AddressApplication
{
    public class DadosCEPService : ICEPRepository
    {
        private readonly IAddressRepository _dadosRepository;
        private readonly DadosCEPDomainService _dadosCEPDomainService;
        private readonly IValidationCepService _validationCepService;
        private readonly IMapper _mapper;

        public DadosCEPService(IAddressRepository dadosRepository , DadosCEPDomainService dadosCEPDomainService, IValidationCepService validationCepService, IMapper mapper)
        {
            _dadosRepository = dadosRepository;
            _dadosCEPDomainService = dadosCEPDomainService;
            _validationCepService = validationCepService;
            _mapper = mapper;
        }

        public Task<Address> GetAddress(string cep, CancellationToken cancellationToken = default)
        {
            return _dadosRepository.GetAddressAsync(cep);
        }

        public async Task<ObjectResponse> PostAddressAsync(string cep, CancellationToken cancellationToken = default)
        {
            var val = _validationCepService.Validation(cep);

            if (!val.IsValid)
            {
                throw new Exception(val.Message);
            }

            var retorno = await _dadosCEPDomainService.NewAddressAsync(cep, cancellationToken);

            Address address  = _mapper.Map<Address>(retorno);

            if (address.Cep == null)
                throw new Exception("Cep inexistente.");   

            await _dadosRepository.PostAsync(address);

            return val;
        }
    }
}
