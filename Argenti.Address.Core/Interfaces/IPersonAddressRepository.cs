using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Argenti.Address.Core.Domain;

namespace Argenti.Address.Core
{
    public interface IPersonAddressRepository
    {
        Task<List<PersonAddressCityGroup>> GetPersonAddressGroupedByCityAsync();
    }
}
