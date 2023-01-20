using AddressApplication;

namespace CEP.AddressApplication.Interface
{
    public interface IValidationCepService
    {
        ObjectResponse Validation(string cep);
    }
}
