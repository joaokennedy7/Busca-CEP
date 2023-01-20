using CEP.AddressInfra.Data;
using AddressDomain.Entities;
using AddressInfra.Repository;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace AddressInfra.RepositoryService
{
    public class AddressRepositoryService : BaseRepository,  IAddressRepository
    {
        public AddressRepositoryService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Address> GetAddressAsync(string cep)
        {
            cep = cep.Replace("-", "");
            using (IDbConnection connection = Connection)
                return await connection.QueryFirstOrDefaultAsync<Address>(Queries.GetCep(), new {cep});
        }

        public async Task PostAsync(Address address)
        {
            var cep = address.Cep.Replace("-", "");
            var logradouro = address.Logradouro;
            var complemento = address.Complemento;
            var bairro = address.Bairro;
            var localidade = address.Localidade;
            var uf = address.UF;
            var ibge = address.Ibge;
            var gia = address.Gia;
            var ddd = address.DDD;
            var siafi = address.Siafi;


            using (IDbConnection connection = Connection)
                await connection.ExecuteAsync(Queries.PostAddress(), new {
                    cep,
                    logradouro,
                    complemento,
                    bairro,
                    localidade,
                    uf,
                    ibge,
                    gia,
                    ddd,
                    siafi
                });
        }
    }
}
