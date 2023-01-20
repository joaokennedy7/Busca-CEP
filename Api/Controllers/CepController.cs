using AddressApplication.Interface;
using AddressDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly ICEPRepository _dadosAddressService;

        public CepController(ICEPRepository dadosAddressService)
        {
            _dadosAddressService = dadosAddressService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAddressAsync(string cep, CancellationToken cancellationToken = default)
        {
            try
            {
                await _dadosAddressService.PostAddressAsync(cep, cancellationToken);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }     

            return Ok("Endereço salvo com sucesso");
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<Address>> GetAddress(string cep, CancellationToken cancellationToken = default)
        {
            var address = await _dadosAddressService.GetAddress(cep, cancellationToken);

            if (address is null)
                return NotFound("Endereço não cadastrado na nossa base de dados.");

            return Ok(address);
        }
    }
}
