using CEP.AddressApplication.Interface;
using AddressApplication;
using AddressInfra.Repository;

namespace CEP.AddressApplication.Services
{
    public class ValidationCepService : IValidationCepService
    {
        private readonly IAddressRepository _dadosRepository;

        public ValidationCepService(IAddressRepository dadosRepository)
        {
            _dadosRepository = dadosRepository;
        }

        public ObjectResponse Validation(string cep)
        {
            if (string.IsNullOrEmpty(cep))
            {
                return new ObjectResponse { IsValid = false, Message = "Esse endereço não encontrado." };
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(cep, ("[0-9]{5}-?[0-9]{3}")))
            {
                return new ObjectResponse { IsValid = false, Message = "Formato inválido de Cep." };
            }
            if (_dadosRepository.GetAddressAsync(cep).Result != null)
            {
                return new ObjectResponse { IsValid = false, Message = "Esse endereço já foi cadastrado." };
            }            

            return new ObjectResponse { IsValid = true, Message = "" };
        }
    }
}
