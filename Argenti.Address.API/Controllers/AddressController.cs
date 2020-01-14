using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Argenti.Address.Core;
using Argenti.Address.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Argenti.Address.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IPersonAddressRepository _personAddressRepository;

        public AddressController(IPersonAddressRepository personAddressRepository)
        {
            _personAddressRepository = personAddressRepository;
        }
               

        [HttpGet]
        [Route("addressesByCity")]
        public async Task<IEnumerable<PersonAddressCityGroup>> Get()
        {
            var result = await _personAddressRepository.GetPersonAddressGroupedByCityAsync();

            return result;
        }
    }
}
