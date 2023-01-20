using CEPDomain.Contracts;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CEPDomain
{
    public class CorreiosServices
    {
        private readonly HttpClient _httpClient;

        public CorreiosServices(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task<TResult> GetAsync<TResult>(IAPICommand command, CancellationToken cancellationToken = default) where TResult : class
        {
            var response = await _httpClient.GetAsync(command.EndpointPath, cancellationToken);                            

            if (response.IsSuccessStatusCode)
            {
                string stringResult = await response.Content.ReadAsStringAsync(cancellationToken);
                return JsonConvert.DeserializeObject<TResult>(stringResult);
            }

            throw new Exception("Formato inválido de CEP.");
        }
    }
}
