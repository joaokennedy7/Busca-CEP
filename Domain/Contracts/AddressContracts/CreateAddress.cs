namespace CEPDomain.Contracts.AddressContracts
{
    public class CreateAddress : IAPICommand
    { 
        public CreateAddress(string cep)
        {
            Cep = cep;
        }
        public string EndpointPath => $"{Cep}/json/";

        public string Cep { get; set; }
    }
}

